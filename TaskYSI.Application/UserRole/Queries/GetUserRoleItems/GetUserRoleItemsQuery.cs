using MediatR;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Application.UserRole.Queries.GetUserRoleItems;

public record GetUserRoleItemsQuery : IRequest<List<UserRoleResponse>>;
