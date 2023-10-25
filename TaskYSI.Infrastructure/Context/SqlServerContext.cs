using Microsoft.EntityFrameworkCore;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Infrastructure.Context;

public class SqlServerContext : DbContext, IDatabaseContext
{
    public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

    public required DbSet<CourseModel> Courses { get; set; }
}