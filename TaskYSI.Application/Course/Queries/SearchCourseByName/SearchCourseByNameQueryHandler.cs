using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskYSI.Domain.Models.Course;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Course.Queries.SearchCourseByName;

public class SearchCourseByNameQueryHandler: IRequestHandler<SearchCourseByNameQuery, List<SearchCourseResult>>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public SearchCourseByNameQueryHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SearchCourseResult>> Handle(SearchCourseByNameQuery request, CancellationToken cancellationToken)
    {
        var keyword = request.Keyword.ToLower(); // Mengonversi keyword ke huruf kecil untuk pencarian case-insensitive

        var matchingCourses = await _context.Courses
            .Where(course => course.CourseName.ToLower().Contains(keyword))
            .ProjectTo<SearchCourseResult>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return matchingCourses;
    }
}