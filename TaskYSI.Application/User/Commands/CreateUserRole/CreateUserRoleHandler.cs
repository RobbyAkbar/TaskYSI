using AutoMapper;
using MediatR;
using TaskYSI.Domain.Models.UserRole;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.User.Commands.CreateUserRole;

public class CreateUserRoleHandler: IRequestHandler<CreateUserRoleCommand, UserRoleResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public CreateUserRoleHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserRoleResponse> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
    {
        var userRole = _mapper.Map<UserRoleModel>(request);
        _context.UserRoles.Add(userRole);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UserRoleResponse>(userRole);
    }
}