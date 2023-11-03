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
            var result = await _client.ExecuteAsync<PaginatedListResponse<CourseResponse>>(request);

            return result is { IsSuccessful: true, Data: not null } ? result.Data.Items.ToList() : null;
        }

        public async Task<CourseResponse?> GetCourse(Guid id)
        {
            var request = new RestRequest($"api/Course/{id}");
            var result = await _client.ExecuteAsync<CourseResponse>(request);

            return result.Data;
        }

        public async Task<RestResponse> UpdateCourse(CourseData course)
        {
            var request = new RestRequest("api/Course");
            request.AddObject(course);
            return await _client.PutAsync(request);
        }

        public async Task<RestResponse> PostCourse(CourseData course)
        {
            var request = new RestRequest("api/Course");
            request.AddObject(course);
            return await _client.PostAsync(request);
        }

        public async Task<RestResponse> DeleteCourse(Guid id)
        {
            var request = new RestRequest($"api/courses/{id}");
            return await _client.DeleteAsync(request);
        }

        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
