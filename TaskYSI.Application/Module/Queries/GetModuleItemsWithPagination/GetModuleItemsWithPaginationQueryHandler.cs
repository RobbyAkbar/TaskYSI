using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Application.Common.Mappings;
using TaskYSI.Application.Common.Models;
using TaskYSI.Domain.Models.Module;

namespace TaskYSI.Application.Module.Queries.GetModuleItemsWithPagination;

public class GetModuleItemsWithPaginationQueryHandler: IRequestHandler<GetModuleItemsWithPaginationQuery, PaginatedList<ModuleResponse>>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public GetModuleItemsWithPaginationQueryHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ModuleResponse>> Handle(GetModuleItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Modules
            .OrderBy(x => x.ModuleName)
            .ProjectTo<ModuleResponse>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}