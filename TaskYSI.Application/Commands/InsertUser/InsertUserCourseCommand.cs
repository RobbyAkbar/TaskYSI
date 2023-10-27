using MediatR;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.Commands.InsertUser;

public record InsertUserCourseCommand(Guid UserId, string RedeemCourseJson) : IRequest<UserCourseResponse>;