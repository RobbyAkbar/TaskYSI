using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskYSI.Application.Commands.InsertModule;
using TaskYSI.Domain.Models.Module;
using TaskYSI.Infrastructure.Context;

namespace TaskYSI.Application.Handlers.Module;

public class InsertModuleHandler: IRequestHandler<InsertModuleCommand, ModuleResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IMapper _mapper;

    public InsertModuleHandler(IDatabaseContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<ModuleResponse> Handle(InsertModuleCommand request, CancellationToken cancellationToken)
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