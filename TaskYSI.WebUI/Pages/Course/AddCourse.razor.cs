using Microsoft.AspNetCore.Components;
using TaskYSI.Domain.Models.Module;
using TaskYSI.WebUI.Data;
using TaskYSI.WebUI.Services;

namespace TaskYSI.WebUI.Pages.Course;

public partial class AddCourse
{
    [Inject] private ICourseService Service { get; set; } = default!;
    [Inject] private NavigationManager NavigationManager { get; set; } = default!;
    
    private CourseData _course = new();
    private IEnumerable<ModuleResponse>? _modules;
    [Parameter] public Guid Id { get; set; }
    [Parameter] public string Guid { get; set; } = default!;

    private bool _isEdit;

    protected override Task OnInitializedAsync()
    {
        if (System.Guid.TryParse(Guid, out var courseId))
        {
            Id = courseId;
        }
        return base.OnInitializedAsync();
    }

    private async void OnSubmit()
    {
        if (Id != System.Guid.Empty)
        {
            await Service.UpdateCourse(Id, _course);
            NavigationManager.NavigateTo("/course");
        }
        else
        {
            await Service.PostCourse(_course);
            _course = new CourseData();
            StateHasChanged();
        }
       
    }

    private Task LoadData()
    {
        return OnParametersSetAsync();
    }

    protected override async Task OnParametersSetAsync()
    {
        if(Id != System.Guid.Empty)
        {
            var course = await Service.GetCourse(Id);
            if (course is not null)
            {
                _course = new CourseData
                {
                    Id = course.Id,
                    CourseName = course.CourseName,
                    Description = course.Description
                };
                _modules = course.Modules;
                _isEdit = true;
            }
        }
    }
    
    private async Task OnDelete(int id)
    {
        await LoadData();
        StateHasChanged();
    }
}