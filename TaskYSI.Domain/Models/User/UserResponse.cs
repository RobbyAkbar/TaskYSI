using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Domain.Models.User;

public class UserResponse: BaseEntity
{
    public required string Email { get; set; }
    public required string IsVerified { get; set; }
    public required UserRoleModel Role { get; set; }
}