using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Application.Common.Mappings;
using TaskYSI.Application.Common.Models;
using TaskYSI.Domain.Models.Module;

namespace TaskYSI.Application.Module.Queries.GetModuleItemsWithPagination;

public class GetModuleItemsWithPaginationQueryHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetModuleItemsWithPaginationQuery, PaginatedList<ModuleResponse>>
{
    public async Task<PaginatedList<ModuleResponse>> Handle(GetModuleItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await context.Modules
            .OrderBy(x => x.ModuleName)
            .ProjectTo<ModuleResponse>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}