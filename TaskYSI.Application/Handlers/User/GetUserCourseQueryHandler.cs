using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskYSI.Application.Queries.UserCourse;
using TaskYSI.Application.Utils;
using TaskYSI.Domain.Models.Course;
using TaskYSI.Domain.Models.User;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Handlers.User;

public class GetUserCourseQueryHandler : IRequestHandler<GetUserCourseQuery, UserCourseResponse>
{
    private readonly IDatabaseContext _context;
    
    public GetUserCourseQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<UserCourseResponse> Handle(GetUserCourseQuery request, CancellationToken cancellationToken)
    {
        var userCourse = await _context.UserCourses
            .FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

        var userCourseResponse = new UserCourseResponse
        {
            UserId = userCourse!.UserId,
            RedeemCourseJson = DeserializeObject.DeserializeAnonymousType<UserCourse>(userCourse.RedeemCourseJson)
        };
        
        return userCourseResponse;
    }
}