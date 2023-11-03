using TaskYSI.Application.Common.Interfaces;

namespace TaskYSI.Application.Course.Commands.DeleteCourse;

public class DeleteCourseCommandHandler(IDatabaseContext context) : IRequestHandler<DeleteCourseCommand>
{
    public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Courses
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        context.Courses.Remove(entity);

        await context.SaveChangesAsync(cancellationToken);
    }
}