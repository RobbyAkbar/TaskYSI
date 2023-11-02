using FluentValidation;

namespace TaskYSI.Application.User.Commands.CreateUserRole;

public class CreateUserRoleCommandValidator: AbstractValidator<CreateUserRoleCommand>
{
    public CreateUserRoleCommandValidator()
    {
        RuleFor(x => x.RoleName)
            .NotEmpty().WithMessage("Role Name is required.");
    }
}