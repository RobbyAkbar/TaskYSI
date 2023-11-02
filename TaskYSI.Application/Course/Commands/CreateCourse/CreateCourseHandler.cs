using AutoMapper;
using MediatR;
using TaskYSI.Domain.Models.Course;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Course.Commands.CreateCourse;

public class CreateCourseHandler: IRequestHandler<CreateCourseCommand, CourseResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public CreateCourseHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = _mapper.Map<CourseModel>(request);
        _context.Courses.Add(course);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CourseResponse>(course);
    }
}