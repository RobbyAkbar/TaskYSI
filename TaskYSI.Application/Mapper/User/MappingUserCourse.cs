using AutoMapper;
using TaskYSI.Application.Commands.InsertUser;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.Mapper.User;

public class MappingUserCourse : Profile
{
    public MappingUserCourse()
    {
        CreateMap<InsertUserCourseCommand, UserCourseModel>();
        CreateMap<UserCourseModel, UserCourseResponse>();
    }
}