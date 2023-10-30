using Microsoft.Extensions.Options;
using RestSharp;
using TaskYSI.Domain.Models.Course;
using TaskYSI.WebUI.Data;

namespace TaskYSI.WebUI.Services
{
    public class CourseService : ICourseService, IDisposable
    {
        private readonly RestClient _client;

        public CourseService(RestClient client, 
            IOptions<ApiSettings> apiSettings)
        {
            _client = client;
            var apiSetting = apiSettings.Value;
            _client = new RestClient(apiSetting.BaseUrl);
        }

        public async Task<IEnumerable<CourseResponse>?> GetCourses()
        {
            var request = new RestRequest("api/Course");
            var result = await _client.ExecuteAsync<AutoWrapperResponse<PaginatedListResponse<CourseResponse>>>(request);

            return result is { IsSuccessful: true, Data.Result: not null } ? result.Data.Result.Items.ToList() : null;
        }

        public async Task<CourseResponse?> GetCourse(Guid id)
        {
            var request = new RestRequest($"api/Course/{id}");
            var result = await _client.ExecuteAsync<AutoWrapperResponse<CourseResponse>>(request);

            return result.Data?.Result;
        }

        public async Task<string> UpdateCourse(Guid id, CourseData course)
        {
            var result = await _client.PutJsonAsync("api/courses/{id}", course);

            return "Success";
        }

        public async Task<string> PostCourse(CourseData course)
        {
            var request = new RestRequest("api/Course", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddObject(course);
            var result = await _client.ExecuteAsync(request);

            return "Success";
        }

        public async Task<string> DeleteCourse(Guid id)
        {
            var result = await _client.DeleteAsync(new RestRequest($"api/courses/{id}"));

            return "Success";
        }

        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
