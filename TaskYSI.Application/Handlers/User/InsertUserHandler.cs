using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskYSI.Application.Commands.InsertUser;
using TaskYSI.Application.Utils;
using TaskYSI.Domain.Models.User;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Handlers.User;

public class InsertUserHandler: IRequestHandler<InsertUserCommand, UserResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public InsertUserHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        // Validasi ID Role
        var userRole = await _context.UserRoles.FirstOrDefaultAsync(r => r.Id == request.RoleId, cancellationToken);
        if (userRole is null)
        {
            throw new ValidationException("Invalid user role ID.");
        }
        
        var user = _mapper.Map<UserModel>(request);
        user.Password = PasswordManager.HashPassword(user.Password);
        user.Role = userRole;
        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UserResponse>(user);
    }
}