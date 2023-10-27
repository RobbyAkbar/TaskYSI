using MediatR;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Application.Queries.UserRole;

public record GetUserRoleItemsQuery : IRequest<List<UserRoleResponse>>;
