using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using TaskYSI.Application.Mapper;
using TaskYSI.Application.Queries.User;
using TaskYSI.Domain.Models;
using TaskYSI.Domain.Models.User;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Handlers.User;

public class GetUsersWithPaginationQueryHandler: IRequestHandler<GetUsersWithPaginationQuery, PaginatedList<UserResponse>>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public GetUsersWithPaginationQueryHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<UserResponse>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Users
            .OrderBy(x => x.Email)
            .ProjectTo<UserResponse>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}