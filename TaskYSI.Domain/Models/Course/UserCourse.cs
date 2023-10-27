namespace TaskYSI.Domain.Models.Course;

public class Module
{
    public int Id { get; set; }
    public string ModuleName { get; set; } = default!;
}

public class UserCourse
{
    public List<Module> Modules { get; set; } = new();
    public Guid Id { get; set; }
}