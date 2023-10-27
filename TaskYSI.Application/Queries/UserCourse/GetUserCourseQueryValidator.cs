using FluentValidation;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Queries.UserCourse;

public class GetUserCourseQueryValidator: AbstractValidator<GetUserCourseQuery>
{
    private readonly IDatabaseContext _context;
    public GetUserCourseQueryValidator(IDatabaseContext context)
    {
        _context = context;
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Code is required.")
            .Must(ValidUser).WithMessage("Invalid User Id.");
    }
    
    private bool ValidUser(Guid code)
    {
        var user = _context.Users.Any(u => u.Id == code);
        return user;
    }
}