using FluentValidation;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Course.Commands.UpdateCourse;

public class UpdateCourseRequestValidator: AbstractValidator<UpdateCourseRequest>
{
    private readonly IDatabaseContext _context;
    
    public UpdateCourseRequestValidator(IDatabaseContext context)
    {
        _context = context;
        
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Course Id is required.")
            .Must(AlreadyCourse).WithMessage("Invalid CourseId.");
        
        RuleFor(x => x.CourseName)
            .NotEmpty().WithMessage("Course name is required.")
            .MaximumLength(100).WithMessage("Course name cannot exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
    }
    
    private bool AlreadyCourse(Guid courseId)
    {
        var course = _context.Courses.Any(c => c.Id == courseId);
        return course;
    }
}