using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Course.Commands.UpdateCourse;

public class UpdateCourseHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<UpdateCourseRequest, CourseResponse>
{
    public async Task<CourseResponse> Handle(UpdateCourseRequest request, CancellationToken cancellationToken)
    {
        var course = mapper.Map<CourseModel>(request);
        context.Courses.Update(course);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<CourseResponse>(course);
    }
}