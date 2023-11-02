using System.Text.Json;
using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.UserCourse.Commands.CreateUserCourse;

public class CreateUserCourseHandler: IRequestHandler<CreateUserCourseCommand, UserCourseResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public CreateUserCourseHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserCourseResponse> Handle(CreateUserCourseCommand request, CancellationToken cancellationToken)
    {
        var configurationJson = JsonSerializer.Serialize(request.RedeemCourseJson);
        var userCourse = _mapper.Map<UserCourseModel>(request);
        userCourse.RedeemCourseJson = configurationJson;
        
        _context.UserCourses.Add(userCourse);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UserCourseResponse>(userCourse);
    }
}