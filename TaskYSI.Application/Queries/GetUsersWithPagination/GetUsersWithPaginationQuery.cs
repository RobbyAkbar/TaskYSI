using MediatR;
using TaskYSI.Domain.Models;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.Queries.GetUsersWithPagination;

public record GetUsersWithPaginationQuery : IRequest<PaginatedList<UserResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}