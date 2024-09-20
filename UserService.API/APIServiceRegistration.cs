using Microsoft.OpenApi.Models;
using UserService.Application;
using UserService.Infrastructure;

namespace UserService.API;

public static class APIServiceRegistration
{
    public static IServiceCollection AddAPIServices(this IServiceCollection services)
    {
        services.AddDistributedMemoryCache();
        services.AddHttpContextAccessor();
        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(60);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
            options.Cookie.Name = "UserService.Session";
        });

        services.AddCors(options =>
        {
            options.AddPolicy(
                "CorsPolicy",
                builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );
        });
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
            c.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Title = "User Service API",
                    Version = "v1",
                    Description = "API para gerenciamento de usuários no User Service",
                }
            )
        );
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddApplicationServices();
        var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetService<IConfiguration>();
        if (configuration != null)
            services.AddInfrastructure(configuration);
        else
            throw new InvalidOperationException("Configuration service is not available.");

        return services;
    }
}
