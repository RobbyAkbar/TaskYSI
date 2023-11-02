using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User.Queries.VerifiedUserEmail;

public class VerifiedUserEmailQueryHandler : IRequestHandler<VerifiedUserEmailQuery, UserResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public VerifiedUserEmailQueryHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(VerifiedUserEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Id == request.Code, cancellationToken);

        if (user!.IsVerified)
        {
            throw new ValidationException("Email already verified");
        }

        user.IsVerified = true;
        user.DateUpdated = DateTimeOffset.Now;

        await _context.SaveChangesAsync(cancellationToken);
        var userResponse = _mapper.Map<UserResponse>(user);

        return userResponse;
    }
}