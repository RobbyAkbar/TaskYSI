using MediatR;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.Queries.User;

public record GetUserByEmailQuery(string Email) : IRequest<UserResponse>;