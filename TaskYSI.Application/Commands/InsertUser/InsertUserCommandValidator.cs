using FluentValidation;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Commands.InsertUser;

public class InsertUserCommandValidator: AbstractValidator<InsertUserCommand>
{
    private readonly IDatabaseContext _context;
    public InsertUserCommandValidator(IDatabaseContext context)
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