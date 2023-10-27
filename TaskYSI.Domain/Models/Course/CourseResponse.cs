using TaskYSI.Domain.Models.Module;

namespace TaskYSI.Domain.Models.Course;

public class CourseResponse: BaseEntity
{
    public required string CourseName { get; set; }
    public required string Description { get; set; }
    public required ICollection<ModuleResponse> Modules { get; set; }
}