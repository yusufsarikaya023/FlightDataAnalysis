using Function.Middlewares;
using Infrastructure;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

// Services
builder.Services.InjectApplication();
builder.Services.InjectInfrastructure();

// Middlewares
builder.UseMiddleware<ValidationMiddleware>();

builder.Build().Run();
