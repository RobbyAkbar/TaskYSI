using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskYSI.Domain.Models.Module;

namespace TaskYSI.Infrastructure.Configuration;

public class ModuleConfiguration: IEntityTypeConfiguration<ModuleModel>
{
    public void Configure(EntityTypeBuilder<ModuleModel> builder)
    {
        builder.HasOne(m => m.Course)
            .WithMany(c => c.Modules)
            .HasForeignKey(m => m.CourseId);
    }
}