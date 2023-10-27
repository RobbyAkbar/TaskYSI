using AutoMapper;
using TaskYSI.Application.Commands.InsertUser;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.Mapper.User;

public class MappingUser: Profile
{
    public MappingUser()
    {
        CreateMap<InsertUserCommand, UserModel>();
        CreateMap<UserModel, UserResponse>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
    }
}