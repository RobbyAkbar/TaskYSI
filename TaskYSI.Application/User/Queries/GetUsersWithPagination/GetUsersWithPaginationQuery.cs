using TaskYSI.Application.Common.Models;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User.Queries.GetUsersWithPagination;

public record GetUsersWithPaginationQuery : IRequest<PaginatedList<UserResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}