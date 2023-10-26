using FluentValidation;

namespace TaskYSI.Application.Queries.GetUser;

public class GetUserByEmailQueryValidator: AbstractValidator<GetUserByEmailQuery>
{
    public GetUserByEmailQueryValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email address format.");
    }
}