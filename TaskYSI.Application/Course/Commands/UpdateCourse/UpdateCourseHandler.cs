using AutoMapper;
using MediatR;
using TaskYSI.Domain.Models.Course;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Course.Commands.UpdateCourse;

public class UpdateCourseHandler: IRequestHandler<UpdateCourseRequest, CourseResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public UpdateCourseHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CourseResponse> Handle(UpdateCourseRequest request, CancellationToken cancellationToken)
    {
        var course = _mapper.Map<CourseModel>(request);
        _context.Courses.Update(course);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CourseResponse>(course);
    }
}