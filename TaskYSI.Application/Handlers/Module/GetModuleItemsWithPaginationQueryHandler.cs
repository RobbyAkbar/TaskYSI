using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using TaskYSI.Application.Mapper;
using TaskYSI.Application.Queries.Module;
using TaskYSI.Domain.Models;
using TaskYSI.Domain.Models.Module;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Handlers.Module;

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