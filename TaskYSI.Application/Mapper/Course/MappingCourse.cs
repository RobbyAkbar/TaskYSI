using AutoMapper;
using TaskYSI.Application.Commands.InsertCourse;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Mapper.Course;

public class MappingCourse: Profile
{
    public MappingCourse()
    {
        CreateMap<InsertCourseCommand, CourseModel>();
        CreateMap<CourseModel, CourseResponse>();
        
        CreateMap<CourseModel, SearchCourseResult>();
    }
}