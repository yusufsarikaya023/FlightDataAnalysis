using System.Net;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.Functions.Worker.Middleware;
using Newtonsoft.Json;

namespace Function.Middlewares;

public record LoggerOption(RequestInfo Request, EndpointErrorResponse Response);

public record EndpointErrorResponse(int Status, string Errors);

public record RequestInfo(string Method, string Path, string QueryString, HttpHeadersCollection Headers, string Body);

public class ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger) : IFunctionsWorkerMiddleware
{
    public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            List<string> trace = [];
            var tracer = ex;
            while (tracer is not null)
            {
                trace.Add(tracer.Message);
                tracer = tracer.InnerException;
            }

            // return this response with status code 500
            var httpReqData = await context.GetHttpRequestDataAsync();
            if (httpReqData != null)
            {
                var newHttpResponse = httpReqData.CreateResponse(HttpStatusCode.InternalServerError);
                await newHttpResponse.WriteAsJsonAsync(new
                {
                    status = (int)HttpStatusCode.InternalServerError,
                    message =  "Internal Server Error",
                    errors = trace.ToArray()
                });

                context.GetInvocationResult().Value = newHttpResponse;
                var response = new EndpointErrorResponse((int)newHttpResponse.StatusCode, ex.Message);
                var request = await SerializeRequestAsync(httpReqData);
                var loggerOption = new LoggerOption(request, response);
                logger.LogError(ex,
                    $"ExceptionMiddleware.HandleCustomExceptionResponseAsync: {JsonConvert.SerializeObject(loggerOption)}"
                );
            }
            else
            {
                logger.LogError(ex,
                    $"ExceptionMiddleware.HandleMiddlewareError: {JsonConvert.SerializeObject(ex.Message)}"
                );
            }
        }
    }


    private static async Task<RequestInfo> SerializeRequestAsync(HttpRequestData? request)
    {
        var requestInfo = new RequestInfo(request!.Method,
            request.Url.ToString(),
            request.Url.Query,
            request.Headers,
            await ReadRequestBodyAsync(request)
        );

        return requestInfo;
    }

    private static async Task<string> ReadRequestBodyAsync(HttpRequestData request)
    {
        request.Body.Position = 0;
        using var reader = new StreamReader(request.Body, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        request.Body.Position = 0;
        return body;
    }
}