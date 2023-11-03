using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Application.Common.Mappings;
using TaskYSI.Application.Common.Models;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Course.Queries.GetCourseItemsWithPagination;

public class GetCourseItemsWithPaginationQueryHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetCourseItemsWithPaginationQuery, PaginatedList<CourseResponse>>
{
    public async Task<PaginatedList<CourseResponse>> Handle(GetCourseItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await context.Courses
            .Include(c => c.Modules)
            .OrderBy(x => x.CourseName)
            .ProjectTo<CourseResponse>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}