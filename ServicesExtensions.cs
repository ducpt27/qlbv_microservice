using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using VeXe.Behaviours;
using VeXe.Config.Infrastructure;
using VeXe.Service;
using VeXe.Service.Impl;

namespace VeXe
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            
            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
            services.AddHostedService<JwtRefreshTokenCache>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IExampleService, ExampleService>();

            return services;
        }
    }
}