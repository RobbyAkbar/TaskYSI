namespace TaskYSI.Domain.Models.Course;

public class GetAllCourseResponse
{
    public int Total { get; set; }
    public required List<CourseResponse> Data { get; set; }
}