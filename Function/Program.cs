using Function.Middlewares;

var builder = FunctionsApplication.CreateBuilder(args);

builder.ConfigureFunctionsWebApplication();

builder.Services.InjectApplication();

builder.UseMiddleware<ValidationMiddleware>();

builder.Build().Run();