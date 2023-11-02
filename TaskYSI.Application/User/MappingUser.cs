using TaskYSI.Application.User.Commands.CreateUser;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User;

public class MappingUser: Profile
{
    public MappingUser()
    {
        CreateMap<CreateUserCommand, UserModel>();
        CreateMap<UserModel, UserResponse>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role));
    }
}