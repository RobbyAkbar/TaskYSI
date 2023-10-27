using FluentValidation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Commands.InsertUser;

public class InsertUserCourseCommandValidator: AbstractValidator<InsertUserCourseCommand>
{
    private readonly IDatabaseContext _context;
    public InsertUserCourseCommandValidator(IDatabaseContext context)
    {
        _context = context;

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .Must(AlreadyUser).WithMessage("Invalid UserId.")
            .Must(NotRedeemCourse).WithMessage("User has redeemed courses");
        
        RuleFor(x => x.RedeemCourseJson)
            .NotEmpty().WithMessage("RedeemCourseJson is required.")
            .Must(BeValidJson).WithMessage("Invalid JSON format for RedeemCourseJson.");
    }
    
    private bool AlreadyUser(Guid userId)
    {
        var user = _context.Users.Any(u => u.Id == userId);
        return user;
    }

    private bool NotRedeemCourse(Guid userId)
    {
        var userCourse = !_context.UserCourses.Any(uc => uc.UserId == userId);
        return userCourse;
    }
    
    private static bool BeValidJson(string json)
    {
        try
        {
            JToken.Parse(json);
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}