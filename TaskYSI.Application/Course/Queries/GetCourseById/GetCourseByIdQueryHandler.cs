using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Course.Queries.GetCourseById;

public class GetCourseByIdQueryHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<GetCourseByIdQuery, CourseResponse>
{
    public async Task<CourseResponse> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var courseEntity = await context.Courses
            .Include(c => c.Modules)
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        
        var courseResponse = mapper.Map<CourseResponse>(courseEntity);
        return courseResponse;
    }
}