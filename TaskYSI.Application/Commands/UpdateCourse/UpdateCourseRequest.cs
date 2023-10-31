using MediatR;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Commands.UpdateCourse;

public sealed record UpdateCourseRequest(Guid Id, string CourseName, string Description) : IRequest<CourseResponse>;