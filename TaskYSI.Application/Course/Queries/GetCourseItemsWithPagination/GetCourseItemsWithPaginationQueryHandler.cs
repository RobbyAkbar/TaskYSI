using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Application.Common.Mappings;
using TaskYSI.Application.Common.Models;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Course.Queries.GetCourseItemsWithPagination;

public class GetCourseItemsWithPaginationQueryHandler: IRequestHandler<GetCourseItemsWithPaginationQuery, PaginatedList<CourseResponse>>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public GetCourseItemsWithPaginationQueryHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CourseResponse>> Handle(GetCourseItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Courses
            .Include(c => c.Modules)
            .OrderBy(x => x.CourseName)
            .ProjectTo<CourseResponse>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}