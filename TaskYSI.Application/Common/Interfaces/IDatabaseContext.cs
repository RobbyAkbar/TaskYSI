using TaskYSI.Domain.Models.Course;
using TaskYSI.Domain.Models.Module;
using TaskYSI.Domain.Models.User;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Application.Common.Interfaces;

public interface IDatabaseContext
{
    DbSet<CourseModel> Courses { get; set; }
    DbSet<UserRoleModel> UserRoles { get; set; }
    DbSet<UserModel> Users { get; set; }
    DbSet<ModuleModel> Modules { get; set; }
    DbSet<UserCourseModel> UserCourses { get; set; }
    DbSet<RolePrivilege> RolePrivileges { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
