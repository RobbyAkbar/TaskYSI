using FluentValidation;

namespace TaskYSI.Application.Commands.InsertModule;

public class InsertModuleCommandValidator: AbstractValidator<InsertModuleCommand>
{
    public InsertModuleCommandValidator()
    {
        RuleFor(x => x.ModuleName)
            .NotEmpty().WithMessage("Module Name is required.");

        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("CourseId is required.");
    }
}