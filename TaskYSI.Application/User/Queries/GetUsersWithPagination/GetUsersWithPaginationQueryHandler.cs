using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Application.Common.Mappings;
using TaskYSI.Application.Common.Models;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User.Queries.GetUsersWithPagination;

public class GetUsersWithPaginationQueryHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetUsersWithPaginationQuery, PaginatedList<UserResponse>>
{
    public async Task<PaginatedList<UserResponse>> Handle(GetUsersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await context.Users
            .OrderBy(x => x.Email)
            .ProjectTo<UserResponse>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}