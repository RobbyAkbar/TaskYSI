using Microsoft.Extensions.Configuration;
using TaskYSI.Application.Common.Exceptions;
using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Application.Utils;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User.Queries.LoginUser;

public class LoginUserQueryHandler(IDatabaseContext context, IMapper mapper, IConfiguration config)
    : IRequestHandler<LoginUserQuery, LoginUserResponse>
{
    public async Task<LoginUserResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var currentUser = await context.Users.Include(u => u.Role).FirstOrDefaultAsync(
            x => x.Email == request.Email,
            cancellationToken: cancellationToken);

        if (currentUser == null)
        {
            throw new UserNotFoundException("Email tidak terdaftar.");
        }

        if (!PasswordManager.VerifyPassword(request.Password, currentUser.Password))
        {
            throw new FormatException("Kata sandi salah.");
        }

        if (!currentUser.IsVerified)
        {
            throw new FormatException("Email belum terverifikasi.");
        }

        var user = mapper.Map<LoginUserResponse>(currentUser);
        user.AccessToken = new AccessToken(config).GenerateToken(currentUser);

        return user;
    }
}