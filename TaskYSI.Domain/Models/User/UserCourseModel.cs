namespace TaskYSI.Domain.Models.User;

public class UserCourseModel
{
    public Guid UserId { get; set; }
    public required string RedeemCourseJson { get; set; }
    public required UserModel User { get; set; }
}