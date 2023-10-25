using Microsoft.EntityFrameworkCore;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Infrastructure.Context;

public interface IDatabaseContext
{
    DbSet<CourseModel> Courses { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
