using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Application.Course.Commands.CreateCourse;

public class CreateCourseHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<CreateCourseCommand, CourseResponse>
{
    public async Task<CourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = mapper.Map<CourseModel>(request);
        context.Courses.Add(course);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<CourseResponse>(course);
    }
}