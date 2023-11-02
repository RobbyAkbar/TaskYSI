using TaskYSI.Application.User.Commands.CreateUser;
using TaskYSI.Application.User.Queries.LoginUser;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User;

public class MappingUser: Profile
{
    public MappingUser()
    {
        CreateMap<CreateUserCommand, UserModel>();
        CreateMap<LoginUserQuery, UserModel>();
        CreateMap<UserModel, UserResponse>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
        CreateMap<UserModel, LoginUserResponse>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
    }
}