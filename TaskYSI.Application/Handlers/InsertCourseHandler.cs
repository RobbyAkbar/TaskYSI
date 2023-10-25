using AutoMapper;
using MediatR;
using TaskYSI.Application.Commands;
using TaskYSI.Domain.Models.Course;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Handlers;

public class InsertCourseHandler: IRequestHandler<InsertCourseCommand, CourseResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public InsertCourseHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CourseResponse> Handle(InsertCourseCommand request, CancellationToken cancellationToken)
    {
        var course = _mapper.Map<CourseModel>(request);
        _context.Courses.Add(course);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CourseResponse>(course);
    }
}