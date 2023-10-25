using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace TaskYSI.Application;

public static class DependencyInjection
{
    public static void AddApplicationService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        /*serviceCollection.AddMvcCore(opt =>
        {
            opt.Filters.Add(typeof(GlobalExceptionFilters));
        });*/
    }
}