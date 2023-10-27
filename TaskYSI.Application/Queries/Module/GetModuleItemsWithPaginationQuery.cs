using MediatR;
using TaskYSI.Domain.Models;
using TaskYSI.Domain.Models.Module;

namespace TaskYSI.Application.Queries.Module;

public record GetModuleItemsWithPaginationQuery : IRequest<PaginatedList<ModuleResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}