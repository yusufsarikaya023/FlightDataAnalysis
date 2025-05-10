using Application.Services;
using Application.Validations;
using Domain.Abstract;

namespace Application;

public static class ServiceRegister
{
    public static void InjectApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        services.AddValidatorsFromAssembly(typeof(PaginationValidator).Assembly);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddTransient<IFileReaderService, FileReaderService>();
    }
}