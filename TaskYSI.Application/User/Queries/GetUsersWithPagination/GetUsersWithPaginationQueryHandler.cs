using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Application.Common.Mappings;
using TaskYSI.Application.Common.Models;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User.Queries.GetUsersWithPagination;

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