using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Course.Commands.CreateCourse;

public record CreateCourseCommand(string CourseName, string Description) : IRequest<CourseResponse>;