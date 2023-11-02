using TaskYSI.Application.Common.Models;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Course.Queries.GetCourseItemsWithPagination;

public record GetCourseItemsWithPaginationQuery : IRequest<PaginatedList<CourseResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}