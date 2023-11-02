using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureService(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var databaseProvider = configuration.GetValue<string>("Database:Provider");
        switch (databaseProvider)
        {
            case "SQL_SERVER":
                var sqlServerConnection = configuration.GetConnectionString("SqlServerConnection");
                serviceCollection.AddDbContext<IDatabaseContext, SqlServerContext>((sp, options) =>
                {
                    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                    options.UseSqlServer(sqlServerConnection);
                });
                break;
            case "POSTGRESQL":
                var postgreSqlConnection = configuration.GetConnectionString("PostgreSqlConnection");
                serviceCollection.AddDbContext<IDatabaseContext, PostgreSqlContext>((sp, options) =>
                {
                    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                    options.UseNpgsql(postgreSqlConnection);
                });
                break;
            default:
                throw new InvalidOperationException("Invalid or unsupported database provider specified in configuration.");
        }
    }
}