using System.Text.Json;
using AutoMapper;
using MediatR;
using TaskYSI.Application.Commands.InsertUser;
using TaskYSI.Domain.Models.User;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Handlers.User;

public class InsertUserCourseHandler: IRequestHandler<InsertUserCourseCommand, UserCourseResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public InsertUserCourseHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserCourseResponse> Handle(InsertUserCourseCommand request, CancellationToken cancellationToken)
    {
        var configurationJson = JsonSerializer.Serialize(request.RedeemCourseJson);
        var userCourse = _mapper.Map<UserCourseModel>(request);
        userCourse.RedeemCourseJson = configurationJson;
        
        _context.UserCourses.Add(userCourse);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UserCourseResponse>(userCourse);
    }
}