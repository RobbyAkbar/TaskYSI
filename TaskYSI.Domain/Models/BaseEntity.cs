namespace TaskYSI.Domain.Models;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset DateCreated { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? DateUpdated { get; set; }
}