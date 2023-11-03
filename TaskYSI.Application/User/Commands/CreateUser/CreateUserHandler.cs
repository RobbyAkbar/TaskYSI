using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Application.Utils;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User.Commands.CreateUser;

public class CreateUserHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<CreateUserCommand, UserResponse>
{
    public async Task<UserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Validasi ID Role
        var userRole = await context.UserRoles.FirstOrDefaultAsync(r => r.Id == request.RoleId, cancellationToken);
        if (userRole is null)
        {
            throw new ValidationException("Invalid user role ID.");
        }
        
        var user = mapper.Map<UserModel>(request);
        user.Password = PasswordManager.HashPassword(user.Password);
        user.Role = userRole;
        context.Users.Add(user);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<UserResponse>(user);
    }
}