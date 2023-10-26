using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Infrastructure.Configuration;

public class CourseConfiguration: IEntityTypeConfiguration<CourseModel>
{
    public void Configure(EntityTypeBuilder<CourseModel> builder)
    {
        builder.HasMany(c => c.Categories)
            .WithMany(c => c.Courses)
            .UsingEntity(j => j.ToTable("CourseCategory"));
    }
}