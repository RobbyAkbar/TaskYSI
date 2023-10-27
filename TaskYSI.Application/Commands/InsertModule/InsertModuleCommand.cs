using MediatR;
using TaskYSI.Domain.Models.Module;

namespace TaskYSI.Application.Commands.InsertModule;

public record InsertModuleCommand(string ModuleName, Guid CourseId) : IRequest<ModuleResponse>;