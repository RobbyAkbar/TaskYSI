using AutoMapper;
using TaskYSI.Application.Commands;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Mapper;

public class MappingCourse: Profile
{
    public MappingCourse()
    {
        CreateMap<InsertCourseCommand, CourseModel>();
        CreateMap<CourseModel, CourseResponse>();
    }
}