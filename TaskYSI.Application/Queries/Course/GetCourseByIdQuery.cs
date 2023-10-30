using MediatR;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Queries.Course;

public record GetCourseByIdQuery(Guid Id) : IRequest<CourseResponse>;
