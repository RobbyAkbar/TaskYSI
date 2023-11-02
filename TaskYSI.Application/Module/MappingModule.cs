using TaskYSI.Application.Module.Commands.CreateModule;
using TaskYSI.Domain.Models.Module;

namespace TaskYSI.Application.Module;

public class MappingModule: Profile
{
    public MappingModule()
    {
        CreateMap<CreateModuleCommand, ModuleModel>();
        CreateMap<ModuleModel, ModuleResponse>();
    }
}