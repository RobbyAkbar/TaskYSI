namespace TaskYSI.Domain.Models.User;

public class UserProfileModel
{
    public int Id { get; set; }
    public required UserModel User { get; set; }
    public required string LastEducation { get; set; }
}