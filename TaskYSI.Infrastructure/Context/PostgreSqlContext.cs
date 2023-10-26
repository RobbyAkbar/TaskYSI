using Microsoft.EntityFrameworkCore;
using TaskYSI.Domain.Models.Course;
using TaskYSI.Domain.Models.User;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Infrastructure.Context;

public class PostgreSqlContext : DbContext, IDatabaseContext
{
    public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options) { }

    public required DbSet<CourseModel> Courses { get; set; }
    public required DbSet<UserRoleModel> UserRoles { get; set; }
    public required DbSet<UserModel> Users { get; set; }
}