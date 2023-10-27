using AutoMapper;
using TaskYSI.Application.Commands.InsertModule;
using TaskYSI.Domain.Models.Module;

namespace TaskYSI.Application.Mapper.Module;

public class MappingModule: Profile
{
    public MappingModule()
    {
        CreateMap<InsertModuleCommand, ModuleModel>();
        CreateMap<ModuleModel, ModuleResponse>();
    }
}