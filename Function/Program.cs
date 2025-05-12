using Function.Middlewares;
using Infrastructure;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Services for registration and DI
builder.Services.InjectApplication();
builder.Services.InjectInfrastructure();

// Middlewares for error handling and validation
builder.UseMiddleware<ExceptionHandlerMiddleware>();
builder.UseMiddleware<ValidationMiddleware>();

builder.Build().Run();
