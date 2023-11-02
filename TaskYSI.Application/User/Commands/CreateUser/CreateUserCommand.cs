using MediatR;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User.Commands.CreateUser;

public record CreateUserCommand(string Email, string Password, int RoleId) : IRequest<UserResponse>;