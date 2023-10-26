using AutoMapper;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.Mapper;

public class MappingGetAllUser: Profile
{
    public MappingGetAllUser()
    {
        CreateMap<UserModel, UserResponse>(); // Map CourseModel ke CourseResponse jika diperlukan

        CreateMap<List<UserModel>, GetAllUserResponse>()
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Count))
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.ToList()));
    }
}