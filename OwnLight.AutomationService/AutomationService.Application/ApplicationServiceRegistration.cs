using System.Reflection;
<<<<<<< HEAD
using MediatR;
using Microsoft.Extensions.DependencyInjection;
=======
using AutomationService.Application.Common.Services;
using AutomationService.Application.Common.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396

namespace AutomationService.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
<<<<<<< HEAD
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

=======
        services.AddScoped<RoutineSchedulerService>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddHttpClient<IDeviceServiceClient, DeviceServiceClient>(client =>
            client.BaseAddress = new Uri("http://localhost:5034") // URL do DeviceService
        );
        services.AddHttpClient<IUserServiceClient, UserServiceClient>(client =>
            client.BaseAddress = new Uri("http://localhost:5008") // URL do UserService
        );

        services.AddQuartz(q =>
        {
            q.SchedulerId = "AutomationService";
            q.UseSimpleTypeLoader();
            q.UseInMemoryStore();
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
        return services;
    }
}
