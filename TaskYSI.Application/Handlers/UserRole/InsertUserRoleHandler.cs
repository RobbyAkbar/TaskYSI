using AutoMapper;
using MediatR;
using TaskYSI.Application.Commands.InsertUserRole;
using TaskYSI.Domain.Models.UserRole;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Handlers.UserRole;

public class InsertUserRoleHandler: IRequestHandler<InsertUserRoleCommand, UserRoleResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public InsertUserRoleHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserRoleResponse> Handle(InsertUserRoleCommand request, CancellationToken cancellationToken)
    {
        var userRole = _mapper.Map<UserRoleModel>(request);
        _context.UserRoles.Add(userRole);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UserRoleResponse>(userRole);
    }
}