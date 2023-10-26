using MediatR;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.Queries.GetUser;

public record GetUserByEmailQuery(string Email) : IRequest<UserResponse>;