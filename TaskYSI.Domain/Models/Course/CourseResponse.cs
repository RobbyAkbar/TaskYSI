namespace TaskYSI.Domain.Models.Course;

public class CourseResponse: BaseEntity
{
    public required string CourseName { get; set; }
    public required string Description { get; set; }
}