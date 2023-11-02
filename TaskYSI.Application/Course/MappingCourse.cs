using AutoMapper;
using TaskYSI.Application.Course.Commands.CreateCourse;
using TaskYSI.Application.Course.Commands.UpdateCourse;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Course;

public class MappingCourse: Profile
{
    public MappingCourse()
    {
        CreateMap<CreateCourseCommand, CourseModel>();
        CreateMap<UpdateCourseRequest, CourseModel>();
        
        CreateMap<CourseModel, CourseResponse>();
        
        CreateMap<CourseModel, SearchCourseResult>();
    }
}