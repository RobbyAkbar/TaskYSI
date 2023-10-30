using Microsoft.AspNetCore.Components;
using TaskYSI.Domain.Models.Course;
using TaskYSI.WebUI.Services;

namespace TaskYSI.WebUI.Pages.Course;

public partial class Course
{
    private IEnumerable<CourseResponse>? _courses;

    [Inject] private ICourseService Service { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        _courses = await Service.GetCourses();
    }

    private async Task LoadData()
    {
        _courses = await Service.GetCourses();
    }

    private async Task OnDelete(Guid id)
    {
        await LoadData();
        StateHasChanged();
    }
}