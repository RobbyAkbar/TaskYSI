using MediatR;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.Commands.InsertUser;

public record InsertUserCommand(string Email, string Password, int RoleId) : IRequest<UserResponse>;