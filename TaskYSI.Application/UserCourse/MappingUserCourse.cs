using AutoMapper;
using TaskYSI.Application.UserCourse.Commands.CreateUserCourse;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.UserCourse;

public class MappingUserCourse : Profile
{
    public MappingUserCourse()
    {
        CreateMap<CreateUserCourseCommand, UserCourseModel>();
        CreateMap<UserCourseModel, UserCourseResponse>();
    }
}