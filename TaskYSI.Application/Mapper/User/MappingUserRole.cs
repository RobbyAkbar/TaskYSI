using AutoMapper;
using TaskYSI.Application.Commands.InsertUserRole;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Application.Mapper.User;

public class MappingUserRole: Profile
{
    public MappingUserRole()
    {
        CreateMap<InsertUserRoleCommand, UserRoleModel>();
        CreateMap<UserRoleModel, UserRoleResponse>();
    }
}