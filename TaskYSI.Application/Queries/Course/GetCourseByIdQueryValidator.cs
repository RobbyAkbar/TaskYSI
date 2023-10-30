using FluentValidation;

namespace TaskYSI.Application.Queries.Course;

public class GetCourseByIdQueryValidator: AbstractValidator<GetCourseByIdQuery>
{
    public GetCourseByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("CourseId is required.");
    }
}