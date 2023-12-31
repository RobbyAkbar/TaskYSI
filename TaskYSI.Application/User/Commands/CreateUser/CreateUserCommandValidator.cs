using TaskYSI.Application.Common.Interfaces;

namespace TaskYSI.Application.User.Commands.CreateUser;

public class CreateUserCommandValidator: AbstractValidator<CreateUserCommand>
{
    private readonly IDatabaseContext _context;
    public CreateUserCommandValidator(IDatabaseContext context)
    {
        _context = context;
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address format.")
            .Must(BeUniqueEmail).WithMessage("Email address already exists.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

        RuleFor(x => x.RoleId)
            .NotEmpty().WithMessage("RoleId is required.");
    }
    
    private bool BeUniqueEmail(string email)
    {
        // Check if email already exists in the database
        var user = !_context.Users.Any(u => u.Email == email);
        return user;
    }
}