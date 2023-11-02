using TaskYSI.Application.User.Commands.CreateUserRole;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Application.UserRole;

public class MappingUserRole: Profile
{
    public MappingUserRole()
    {
        CreateMap<CreateUserRoleCommand, UserRoleModel>();
        CreateMap<UserRoleModel, UserRoleResponse>();
    }
}