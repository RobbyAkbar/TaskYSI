using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Infrastructure.Configuration;

public class UserConfiguration: IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasOne(u => u.Role)
            .WithMany()
            .HasForeignKey(u => u.RoleId);
        
        builder.Property(u => u.Email)
            .HasMaxLength(255);
        
        builder.Property(u => u.IsVerified)
            .HasDefaultValue(false);
        
        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}