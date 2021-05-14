using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using VeXe.Common;
using VeXe.Common.Behaviours;
using VeXe.Persistence;
using VeXe.Service;
using VeXe.Service.impl;
using VeXe.Service.Impl;

namespace VeXe
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestLogger<>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IUserService, UserService>();
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<object>>();
            services.AddSingleton(typeof(ILogger), logger);
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = configuration["ConnectionStrings:Default"];
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());

            return services;
        }
    }
}