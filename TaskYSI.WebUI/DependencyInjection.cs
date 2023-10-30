using RestSharp;
using TaskYSI.WebUI.Data;
using TaskYSI.WebUI.Services;

namespace TaskYSI.WebUI;

public static class DependencyInjection
{
    public static void AddConfigureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddSingleton(new RestClient(new HttpClient()));
        
        serviceCollection.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
        serviceCollection.AddScoped<ICourseService, CourseService>();
    }
}