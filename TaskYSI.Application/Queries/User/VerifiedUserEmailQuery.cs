using MediatR;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.Queries.User;

public record VerifiedUserEmailQuery(Guid Code) : IRequest<UserResponse>;
