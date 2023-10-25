namespace TaskYSI.Domain.Models.Course;

public class CourseResponse
{
    public Guid Id { get; set; }
    public required string CourseName { get; set; }
    public required string Description { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset? DateUpdated { get; set; }
}