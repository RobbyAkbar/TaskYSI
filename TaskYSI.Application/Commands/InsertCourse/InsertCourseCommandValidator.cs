using FluentValidation;

namespace TaskYSI.Application.Commands.InsertCourse;

public class InsertCourseCommandValidator: AbstractValidator<InsertCourseCommand>
{
    public InsertCourseCommandValidator()
    {
        RuleFor(x => x.CourseName)
            .NotEmpty().WithMessage("Course name is required.")
            .MaximumLength(100).WithMessage("Course name cannot exceed 100 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
    }
}