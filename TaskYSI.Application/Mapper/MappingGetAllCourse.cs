using AutoMapper;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Mapper;

public class MappingGetAllCourse: Profile
{
    public MappingGetAllCourse()
    {
        CreateMap<CourseModel, CourseResponse>(); // Map CourseModel ke CourseResponse jika diperlukan

        CreateMap<List<CourseModel>, GetAllCourseResponse>()
            .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Count))
            .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.ToList()));
    }
}