using TaskYSI.Domain.Models.Course;
using TaskYSI.WebUI.Data;

namespace TaskYSI.WebUI.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseResponse>?> GetCourses();
        Task<CourseResponse?> GetCourse(Guid id);
        Task<string> UpdateCourse(Guid id, CourseData course);
        Task<string> PostCourse(CourseData course);
        Task<string> DeleteCourse(Guid id);
    }
}
