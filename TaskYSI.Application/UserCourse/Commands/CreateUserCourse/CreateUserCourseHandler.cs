using System.Text.Json;
using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.UserCourse.Commands.CreateUserCourse;

public class CreateUserCourseHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<CreateUserCourseCommand, UserCourseResponse>
{
    public async Task<UserCourseResponse> Handle(CreateUserCourseCommand request, CancellationToken cancellationToken)
    {
        var configurationJson = JsonSerializer.Serialize(request.RedeemCourseJson);
        var userCourse = mapper.Map<UserCourseModel>(request);
        userCourse.RedeemCourseJson = configurationJson;
        
        context.UserCourses.Add(userCourse);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<UserCourseResponse>(userCourse);
    }
}