using MediatR;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.Queries.UserCourse;

public record GetUserCourseQuery(Guid UserId) : IRequest<UserCourseResponse>;
