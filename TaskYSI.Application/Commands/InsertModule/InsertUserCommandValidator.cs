using FluentValidation;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Commands.InsertModule;

public class InsertModuleCommandValidator: AbstractValidator<InsertModuleCommand>
{
    private readonly IDatabaseContext _context;
    public InsertModuleCommandValidator(IDatabaseContext context)
    {
        _context = context;

        RuleFor(x => x.ModuleName)
            .NotEmpty().WithMessage("Module Name is required.");

        RuleFor(x => x.CourseId)
            .NotEmpty().WithMessage("CourseId is required.");
    }
}