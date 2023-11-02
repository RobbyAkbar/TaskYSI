using TaskYSI.Domain.Models.Module;

namespace TaskYSI.Application.Module.Commands.CreateModule;

public record CreateModuleCommand(string ModuleName, Guid CourseId) : IRequest<ModuleResponse>;