using FluentValidation;

namespace TaskYSI.Application.Course.Queries.GetCourseById;

public class GetCourseByIdQueryValidator: AbstractValidator<GetCourseByIdQuery>
{
    public GetCourseByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("CourseId is required.");
    }
}