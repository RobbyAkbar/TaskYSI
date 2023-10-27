using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Infrastructure.Configuration;

public class UserRoleConfiguration: IEntityTypeConfiguration<UserRoleModel>
{
    public void Configure(EntityTypeBuilder<UserRoleModel> builder)
    {
        builder.HasMany(ur => ur.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId);
    }
}