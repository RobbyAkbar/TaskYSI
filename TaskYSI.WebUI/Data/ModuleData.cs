namespace TaskYSI.WebUI.Data;

public class ModuleData
{
    public int Id { get; init; }
    public string ModuleName { get; set; } = default!;
    public Guid CourseId { get; set; }
}