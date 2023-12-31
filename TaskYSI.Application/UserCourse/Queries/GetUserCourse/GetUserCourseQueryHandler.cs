using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Application.Utils;
using TaskYSI.Domain.Models.User;
using UserCourseAlias = TaskYSI.Domain.Models.Course.UserCourse;

namespace TaskYSI.Application.UserCourse.Queries.GetUserCourse;

public class GetUserCourseQueryHandler(IDatabaseContext context) : IRequestHandler<GetUserCourseQuery, UserCourseResponse>
{
    public async Task<UserCourseResponse> Handle(GetUserCourseQuery request, CancellationToken cancellationToken)
    {
        var userCourse = await context.UserCourses
            .FirstOrDefaultAsync(u => u.UserId == request.UserId, cancellationToken);

        var userCourseResponse = new UserCourseResponse
        {
            UserId = userCourse!.UserId,
            RedeemCourseJson = DeserializeObject.DeserializeAnonymousType<UserCourseAlias>(userCourse.RedeemCourseJson)
        };
        
        return userCourseResponse;
    }
}