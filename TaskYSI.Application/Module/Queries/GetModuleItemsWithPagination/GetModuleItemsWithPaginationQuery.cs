using TaskYSI.Application.Common.Models;
using TaskYSI.Domain.Models.Module;

namespace TaskYSI.Application.Module.Queries.GetModuleItemsWithPagination;

public record GetModuleItemsWithPaginationQuery : IRequest<PaginatedList<ModuleResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}