using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Course.Queries.GetCourseById;

public record GetCourseByIdQuery(Guid Id) : IRequest<CourseResponse>;
