using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Domain.Models.Module;

public class ModuleModel
{
    public int Id { get; set; }
    public required string ModuleName { get; set; }
    public required CourseModel Course { get; set; }
    public required Guid CourseId { get; set; }
}