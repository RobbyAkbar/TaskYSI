using FluentValidation;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.User.Queries.VerifiedUserEmail;

public class VerifiedUserEmailQueryValidator: AbstractValidator<VerifiedUserEmailQuery>
{
    private readonly IDatabaseContext _context;
    public VerifiedUserEmailQueryValidator(IDatabaseContext context)
    {
        _context = context;
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required.")
            .Must(ValidCode).WithMessage("Invalid verified code.");
    }
    
    private bool ValidCode(Guid code)
    {
        var user = _context.Users.Any(u => u.Id == code);
        return user;
    }
}