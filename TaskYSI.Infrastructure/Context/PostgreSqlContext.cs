using Microsoft.EntityFrameworkCore;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.Infrastructure.Context;

public class PostgreSqlContext : DbContext, IDatabaseContext
{
    public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options) { }

    public required DbSet<CourseModel> Courses { get; set; }
}