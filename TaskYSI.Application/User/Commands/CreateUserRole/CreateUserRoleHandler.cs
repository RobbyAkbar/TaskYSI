using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Application.User.Commands.CreateUserRole;

public class CreateUserRoleHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<CreateUserRoleCommand, UserRoleResponse>
{
    public async Task<UserRoleResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var userRole = mapper.Map<UserRoleModel>(request);
        context.UserRoles.Add(userRole);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<UserRoleResponse>(userRole);
    }
}