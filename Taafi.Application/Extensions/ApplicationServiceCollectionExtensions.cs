using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Taafi.Application.Interfaces;
using Taafi.Application.Services;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<IAuthService, AuthService>();
        service.AddScoped<IDoctorService, DoctorService>();
        service.AddScoped<IAppointmentService, AppointmentService>();
        service.AddHttpClient<IGeminiService, GeminiService>();
        service.AddScoped<IChatService, ChatService>();
        service.AddScoped<INotificationService, NotificationService>();
        service.AddScoped<ISpecialityService, SpecialityService>();



        service.AddAutoMapper(cfg => cfg.AddProfile<TaafiProfile>());
        return service;
    }
}

