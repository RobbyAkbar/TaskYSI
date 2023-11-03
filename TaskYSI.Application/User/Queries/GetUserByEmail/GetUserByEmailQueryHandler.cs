using TaskYSI.Application.Common.Exceptions;
using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User.Queries.GetUserByEmail;

public class GetUserByEmailQueryHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetUserByEmailQuery, UserResponse>
{
    public async Task<UserResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var userEntity = await context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

        if (userEntity is null)
        {
            throw new UserNotFoundException("Email tidak ditemukan.");
        }

        var userResponse = mapper.Map<UserResponse>(userEntity);
        return userResponse;
    }
}