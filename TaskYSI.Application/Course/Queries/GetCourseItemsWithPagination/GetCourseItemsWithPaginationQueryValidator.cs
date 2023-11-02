namespace TaskYSI.Application.Course.Queries.GetCourseItemsWithPagination;

public class GetCourseItemsWithPaginationQueryValidator: AbstractValidator<GetCourseItemsWithPaginationQuery>
{
    public GetCourseItemsWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}