using FluentValidation;

namespace TaskYSI.Application.Queries.Module;

public class GetModuleItemsWithPaginationQueryValidator: AbstractValidator<GetModuleItemsWithPaginationQuery>
{
    public GetModuleItemsWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}