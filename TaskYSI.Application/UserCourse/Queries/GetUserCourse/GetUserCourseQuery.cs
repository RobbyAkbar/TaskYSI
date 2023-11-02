using MediatR;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.UserCourse.Queries.GetUserCourse;

public record GetUserCourseQuery(Guid UserId) : IRequest<UserCourseResponse>;
