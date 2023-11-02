using MediatR;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User.Queries.VerifiedUserEmail;

public record VerifiedUserEmailQuery(Guid Code) : IRequest<UserResponse>;
