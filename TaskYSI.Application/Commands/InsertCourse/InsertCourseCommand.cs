using MediatR;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Commands.InsertCourse;

public record InsertCourseCommand(string CourseName, string Description) : IRequest<CourseResponse>;