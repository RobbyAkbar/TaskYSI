namespace TaskYSI.WebUI.Data;

public class CourseData
{
    public Guid Id { get; init; }
    public string CourseName { get; set; } = default!;
    public string Description { get; set; } = default!;
}