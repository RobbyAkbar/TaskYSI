using TaskYSI.Application.Common.Interfaces;
using TaskYSI.Domain.Models.Module;

namespace TaskYSI.Application.Module.Commands.CreateModule;

public class CreateModuleHandler: IRequestHandler<CreateModuleCommand, ModuleResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public CreateModuleHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ModuleResponse> Handle(CreateModuleCommand request, CancellationToken cancellationToken)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(r => r.Id == request.CourseId, cancellationToken);
        if (course is null)
        {
            throw new ValidationException("Invalid Course ID.");
        }
        
        var module = _mapper.Map<ModuleModel>(request);
        module.Course = course;
        _context.Modules.Add(module);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ModuleResponse>(module);
    }
}