using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<IAuthService, AuthService>();
        service.AddAutoMapper(cfg => cfg.AddProfile<TaafiProfile>());
        return service;
    }
}

