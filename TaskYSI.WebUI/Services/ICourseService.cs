using RestSharp;
using TaskYSI.Domain.Models.Course;
using TaskYSI.WebUI.Data;

namespace TaskYSI.WebUI.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseResponse>?> GetCourses();
        Task<CourseResponse?> GetCourse(Guid id);
        Task<RestResponse> UpdateCourse(CourseData course);
        Task<RestResponse> PostCourse(CourseData course);
        Task<RestResponse> DeleteCourse(Guid id);
    }
}
