using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Application.UserRole.Queries.GetUserRoleItems;

public class GetUserRoleItemsQueryHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetUserRoleItemsQuery, List<UserRoleResponse>>
{
    public async Task<List<UserRoleResponse>> Handle(GetUserRoleItemsQuery request, CancellationToken cancellationToken)
    {
        var userRoles = await context.UserRoles.ToListAsync(cancellationToken);
        return mapper.Map<List<UserRoleResponse>>(userRoles);
    }
}