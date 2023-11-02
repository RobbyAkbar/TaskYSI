using Microsoft.EntityFrameworkCore;
using TaskYSI.Domain.Models.Category;
using TaskYSI.Domain.Models.Course;
using TaskYSI.Domain.Models.Module;
using TaskYSI.Domain.Models.User;
using TaskYSI.Domain.Models.UserRole;
using TaskYSI.Infrastructure.Configuration;

namespace TaskYSI.Infrastructure.Context;

public class SqlServerContext : DbContext, IDatabaseContext
{
    public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

    public required DbSet<CourseModel> Courses { get; set; }
    public required DbSet<UserRoleModel> UserRoles { get; set; }
    public required DbSet<UserModel> Users { get; set; }
    public required DbSet<ModuleModel> Modules { get; set; }
    public required DbSet<UserCourseModel> UserCourses { get; set; }
    public required DbSet<RolePrivilege> RolePrivileges { get; set; }
    public required DbSet<CategoryModel> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        
        modelBuilder.ApplyConfiguration(new CourseConfiguration());
        modelBuilder.ApplyConfiguration(new ModuleConfiguration());
        modelBuilder.ApplyConfiguration(new UserCourseConfiguration());
    }
}