using System.Reflection;
using System.Text.Json.Serialization;
using Application.UseCases.FlightData;
using FluentValidation;
using Function.Attributes;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Function.Middlewares;

public class ValidationMiddleware : IFunctionsWorkerMiddleware
{
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        var requestData = await context.GetHttpRequestDataAsync();

        if (requestData is null) await next(context);

        var parameter = context.FunctionDefinition.Parameters
            .Count(p => p.Name == "req" && p.Type.ToString() == typeof(HttpRequest).FullName);
        
        if(parameter != 1)
        {
            await next(context);
            return;
        }
        
        
        var httpContext = context.GetHttpContext();
        var httpRequest = httpContext!.Request;
        var requestBody = await httpRequest!.ReadAsStringAsync();
        
        var targetMethod = GetTargetFunctionMethod(context);
        var attribute = targetMethod.GetCustomAttribute<ValidateRequestAttribute>();
        
        if (attribute is null)
        {
            await next(context);
            return;
        }
        
        var type = attribute.Type;
        
        var model = JsonSerializer.Deserialize(requestBody, type,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        
        var validatorType = typeof(IValidator<>).MakeGenericType(type);
        var scope = context.InstanceServices.CreateScope();

        if (scope.ServiceProvider.GetService(validatorType) is IValidator validator)
        {
            var validateMethod = validatorType.GetMethod("Validate", [type]);
            var validationResult = (FluentValidation.Results.ValidationResult)validateMethod?.Invoke(validator, [model])!;
            
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
                var errorResponse = new
                {
                    StatusCode = 400,
                    Message = "Validation failed",
                    Errors = errors
                };
                
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsJsonAsync(errorResponse);
                return;
            }
        }

        await next(context);
    }

    private static MethodInfo GetTargetFunctionMethod(FunctionContext context)
    {
        var entryPoint = context.FunctionDefinition.EntryPoint;
        var assemblyPath = context.FunctionDefinition.PathToAssembly;
        var assembly = Assembly.LoadFrom(assemblyPath);
        var typeName = entryPoint[..entryPoint.LastIndexOf('.')];
        var type = assembly.GetType(typeName);
        var methodName = entryPoint[(entryPoint.LastIndexOf('.') + 1)..];
        var method = type!.GetMethod(methodName);
        return method!;
    }
}