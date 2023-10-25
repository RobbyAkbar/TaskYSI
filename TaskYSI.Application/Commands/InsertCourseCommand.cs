using MediatR;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Commands;

public record InsertCourseCommand(string CourseName, string Description) : IRequest<CourseResponse>;