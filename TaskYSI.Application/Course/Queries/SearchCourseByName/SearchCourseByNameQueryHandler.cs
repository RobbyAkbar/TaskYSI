using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Course.Queries.SearchCourseByName;

public class SearchCourseByNameQueryHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<SearchCourseByNameQuery, List<SearchCourseResult>>
{
    public async Task<List<SearchCourseResult>> Handle(SearchCourseByNameQuery request, CancellationToken cancellationToken)
    {
        var keyword = request.Keyword.ToLower(); // Mengonversi keyword ke huruf kecil untuk pencarian case-insensitive

        var matchingCourses = await context.Courses
            .Where(course => course.CourseName.ToLower().Contains(keyword))
            .ProjectTo<SearchCourseResult>(mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return matchingCourses;
    }
}