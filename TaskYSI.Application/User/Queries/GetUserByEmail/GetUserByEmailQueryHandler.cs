using AutoWrapper.Wrappers;
using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User.Queries.GetUserByEmail;

public class GetUserByEmailQueryHandler: IRequestHandler<GetUserByEmailQuery, UserResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public GetUserByEmailQueryHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserResponse> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var userEntity = await _context.Users
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

        if (userEntity is null)
        {
            throw new ApiException("User not found for the provided email address.");
        }

        var userResponse = _mapper.Map<UserResponse>(userEntity);
        return userResponse;
    }
}