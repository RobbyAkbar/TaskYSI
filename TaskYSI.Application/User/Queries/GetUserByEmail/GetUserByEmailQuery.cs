using MediatR;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User.Queries.GetUserByEmail;

public record GetUserByEmailQuery(string Email) : IRequest<UserResponse>;