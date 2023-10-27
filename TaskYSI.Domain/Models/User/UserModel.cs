using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Domain.Models.User;

public class UserModel: BaseEntity
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool IsVerified { get; set; }
    public required UserRoleModel Role { get; set; }
    public required int RoleId { get; set; }
    public required UserCourseModel UserCourse { get; set; }
}