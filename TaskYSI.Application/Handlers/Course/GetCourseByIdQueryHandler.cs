using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskYSI.Application.Queries.Course;
using TaskYSI.Domain.Models.Course;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Handlers.Course;

public class GetCourseByIdQueryHandler: IRequestHandler<GetCourseByIdQuery, CourseResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public GetCourseByIdQueryHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CourseResponse> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var courseEntity = await _context.Courses
            .Include(c => c.Modules)
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Id == request.Id, cancellationToken);
        
        var courseResponse = _mapper.Map<CourseResponse>(courseEntity);
        return courseResponse;
    }
}