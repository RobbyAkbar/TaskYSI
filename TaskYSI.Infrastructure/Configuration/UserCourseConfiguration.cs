using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.Infrastructure.Configuration;

public class UserCourseConfiguration: IEntityTypeConfiguration<UserCourseModel>
{
    public void Configure(EntityTypeBuilder<UserCourseModel> builder)
    {
        builder.HasKey(uc => uc.UserId);
    }
}