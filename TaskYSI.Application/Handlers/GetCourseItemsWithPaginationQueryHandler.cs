using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using TaskYSI.Application.Mapper;
using TaskYSI.Application.Queries.GetCourseItemsWithPagination;
using TaskYSI.Domain.Models;
using TaskYSI.Domain.Models.Course;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Handlers;

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
            .OrderBy(x => x.CourseName)
            .ProjectTo<CourseResponse>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}