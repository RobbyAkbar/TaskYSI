using MediatR;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Application.Queries.GetUserRole;

public record GetUserRoleItemsQuery : IRequest<List<UserRoleResponse>>;
