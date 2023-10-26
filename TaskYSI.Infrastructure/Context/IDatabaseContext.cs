using Microsoft.EntityFrameworkCore;
using TaskYSI.Domain.Models.Course;
using TaskYSI.Domain.Models.User;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Infrastructure.Context;

public interface IDatabaseContext
{
    DbSet<CourseModel> Courses { get; set; }
    DbSet<UserRoleModel> UserRoles { get; set; }
    DbSet<UserModel> Users { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
