using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Application.User.Commands.CreateUserRole;

public record CreateUserRoleCommand(string RoleName) : IRequest<UserRoleResponse>;