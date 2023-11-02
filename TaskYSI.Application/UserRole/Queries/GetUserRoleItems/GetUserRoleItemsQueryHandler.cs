using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Application.UserRole.Queries.GetUserRoleItems;

public class GetUserRoleItemsQueryHandler: IRequestHandler<GetUserRoleItemsQuery, List<UserRoleResponse>>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public GetUserRoleItemsQueryHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<UserRoleResponse>> Handle(GetUserRoleItemsQuery request, CancellationToken cancellationToken)
    {
        var userRoles = await _context.UserRoles.ToListAsync(cancellationToken);
        return _mapper.Map<List<UserRoleResponse>>(userRoles);
    }
}