using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.Module;

namespace TaskYSI.Application.Module.Commands.CreateModule;

public class CreateModuleHandler(IDatabaseContext context, IMapper mapper) : IRequestHandler<CreateModuleCommand, ModuleResponse>
{
    public async Task<ModuleResponse> Handle(CreateModuleCommand request, CancellationToken cancellationToken)
    {
        var course = await context.Courses.FirstOrDefaultAsync(r => r.Id == request.CourseId, cancellationToken);
        if (course is null)
        {
            throw new ValidationException("Invalid Course ID.");
        }
        
        var module = mapper.Map<ModuleModel>(request);
        module.Course = course;
        context.Modules.Add(module);
        await context.SaveChangesAsync(cancellationToken);

        return mapper.Map<ModuleResponse>(module);
    }
}