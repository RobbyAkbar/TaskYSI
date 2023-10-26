using MediatR;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Application.Commands.InsertUserRole;

public record InsertUserRoleCommand(string RoleName) : IRequest<UserRoleResponse>;