using MediatR;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.UserCourse.Commands.CreateUserCourse;

public record CreateUserCourseCommand(Guid UserId, string RedeemCourseJson) : IRequest<UserCourseResponse>;