using FluentValidation;

namespace TaskYSI.Application.Module.Commands.CreateModule;

public class CreateModuleCommandValidator: AbstractValidator<CreateModuleCommand>
{
    public CreateModuleCommandValidator()
    {
        RuleFor(x => x.ModuleName)
            .NotEmpty().WithMessage("Module Name is required.");

        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("CourseId is required.");
    }
}