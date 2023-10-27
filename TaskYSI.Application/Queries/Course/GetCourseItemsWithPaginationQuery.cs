using MediatR;
using TaskYSI.Domain.Models;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Queries.Course;

public record GetCourseItemsWithPaginationQuery : IRequest<PaginatedList<CourseResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}