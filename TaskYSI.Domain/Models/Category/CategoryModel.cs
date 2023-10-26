using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Domain.Models.Category;

public class CategoryModel
{
    public int Id { get; set; }
    public required string CategoryName { get; set; }
    public required ICollection<CourseModel> Courses { get; set; }
}