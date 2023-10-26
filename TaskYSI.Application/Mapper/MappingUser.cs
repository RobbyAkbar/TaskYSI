using AutoMapper;
using TaskYSI.Application.Commands.InsertUser;
using TaskYSI.Domain.Models.User;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Application.Mapper;

public class MappingUser: Profile
{
    public MappingUser()
    {
        CreateMap<InsertUserCommand, UserModel>();
        
        CreateMap<UserModel, UserResponse>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
        CreateMap<UserRoleModel, UserRoleResponse>(); 
    }
}