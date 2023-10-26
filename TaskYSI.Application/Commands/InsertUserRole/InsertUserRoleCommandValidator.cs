using FluentValidation;

namespace TaskYSI.Application.Commands.InsertUserRole;

public class InsertUserRoleCommandValidator: AbstractValidator<InsertUserRoleCommand>
{
    public InsertUserRoleCommandValidator()
    {
        RuleFor(x => x.RoleName)
            .NotEmpty().WithMessage("Role Name is required.");
    }
}