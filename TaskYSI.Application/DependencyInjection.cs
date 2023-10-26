using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
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
        
        serviceCollection.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        /*serviceCollection.AddMvcCore(opt =>
        {
            opt.Filters.Add(typeof(GlobalExceptionFilters));
        });*/
    }
}