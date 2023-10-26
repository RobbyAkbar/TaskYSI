using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskYSI.Application.Exceptions;
using TaskYSI.Application.Queries.GetUser;
using TaskYSI.Domain.Models.User;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Handlers.User;

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
            .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

        if (userEntity is null)
        {
            throw new NotFoundException("User not found for the provided email address.");
        }

        var userResponse = _mapper.Map<UserResponse>(userEntity);
        return userResponse;
    }
}