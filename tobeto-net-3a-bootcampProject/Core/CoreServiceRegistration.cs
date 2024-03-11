using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core;

public static class CoreServiceRegistration
{
    public static IServiceCollection AddCoreModule(this IServiceCollection services)
    {
        services.AddTransient<MongoDbLogger>();
        services.AddTransient<MssqlLogger>();
        services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<ITokenHelper, JwtHelper>();
        return services;
    }
    public static IServiceCollection AddSubClassesOfType(this IServiceCollection services, Assembly assembly, 
        Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type item in types)
        {
            if (addWithLifeCycle == null)
            {
                services.AddScoped(item);
            }
            else
            {
                addWithLifeCycle(services, item);
            }
        }
        return services;
    }

    public static IServiceCollection RegisterAssemblyTypes(this IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract);
        foreach (Type type in types)
        {
            var interfaces = type.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, type);
            }
        }
        return services;
    }
}
