using FluentValidation;

namespace TaskYSI.Application.User.Queries.GetUserByEmail;

public class GetUserByEmailQueryValidator: AbstractValidator<GetUserByEmailQuery>
{
    public GetUserByEmailQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address format.");
    }
}