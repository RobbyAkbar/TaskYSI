namespace TaskYSI.Domain.Models.User;

public class UserCourseResponse
{
    public Guid UserId { get; set; }
    public object? RedeemCourseJson { get; set; }
}