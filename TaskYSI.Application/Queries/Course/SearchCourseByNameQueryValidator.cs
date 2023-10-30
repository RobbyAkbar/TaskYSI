using FluentValidation;

namespace TaskYSI.Application.Queries.Course;

public class SearchCourseByNameQueryValidator : AbstractValidator<SearchCourseByNameQuery>
{
    public SearchCourseByNameQueryValidator()
    {
        RuleFor(x => x.Keyword)
            .NotEmpty().WithMessage("Keyword is required.")
            .MinimumLength(3).WithMessage("Minimum 3 letter keywords.");
    }
}