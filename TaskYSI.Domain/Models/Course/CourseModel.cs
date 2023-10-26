using TaskYSI.Domain.Models.Category;

namespace TaskYSI.Domain.Models.Course;

public class CourseModel: BaseEntity
{
    public required string CourseName { get; set; }
    public required string Description { get; set; }
    public required ICollection<CategoryModel> Categories { get; set; }
}