using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskYSI.Application.Commands;
using TaskYSI.Domain.Models.Course;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Handlers;

public class GetAllCourseHandler: IRequestHandler<GetAllCourseCommand, GetAllCourseResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public GetAllCourseHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GetAllCourseResponse> Handle(GetAllCourseCommand request, CancellationToken cancellationToken)
    {
        var courses = await _context.Courses.ToListAsync(cancellationToken);
        return _mapper.Map<GetAllCourseResponse>(courses);
    }
}