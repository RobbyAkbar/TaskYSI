using TaskYSI.Application.Common.Interfaces;

namespace TaskYSI.Application.Course.Commands.DeleteCourse;

public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
{
    private readonly IDatabaseContext _context;

    public DeleteCourseCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Courses
            .Where(l => l.Id == request.Id)
            .SingleOrDefaultAsync(cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.Courses.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}