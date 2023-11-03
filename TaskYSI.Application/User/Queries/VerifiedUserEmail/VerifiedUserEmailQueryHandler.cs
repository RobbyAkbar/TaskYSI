using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User.Queries.VerifiedUserEmail;

public class VerifiedUserEmailQueryHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<VerifiedUserEmailQuery, UserResponse>
{
    public async Task<UserResponse> Handle(VerifiedUserEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Id == request.Code, cancellationToken);

        if (user!.IsVerified)
        {
            throw new ValidationException("Email already verified");
        }

        user.IsVerified = true;
        user.DateUpdated = DateTimeOffset.Now;

        await context.SaveChangesAsync(cancellationToken);
        var userResponse = mapper.Map<UserResponse>(user);

        return userResponse;
    }
}