using AutoWrapper.Wrappers;
using Microsoft.Extensions.Configuration;
using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Application.Utils;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User.Queries.LoginUser;

public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _config;

    public LoginUserQueryHandler(IDatabaseContext context, IMapper mapper, IConfiguration config)
    {
        _context = context;
        _mapper = mapper;
        _config = config;
    }

    public async Task<LoginUserResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
    {
        var currentUser = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(
            x => x.Email.ToLower().Contains(request.Email.ToLower()),
            cancellationToken: cancellationToken);

        if (currentUser == null)
        {
            throw new ApiException("Email tidak terdaftar.");
        }

        if (!PasswordManager.VerifyPassword(request.Password, currentUser.Password))
        {
            throw new ApiException("Kata sandi salah.");
        }

        var user = _mapper.Map<LoginUserResponse>(currentUser);
        user.AccessToken = new AccessToken(_config).GenerateToken(currentUser);

        return user;
    }
}