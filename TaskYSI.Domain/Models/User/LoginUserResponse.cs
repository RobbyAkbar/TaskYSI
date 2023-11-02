using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.Domain.Models.User;

public class LoginUserResponse: BaseEntity
{
    public required string Email { get; set; }
    public required string IsVerified { get; set; }
    public required UserRoleResponse Role { get; set; }
    public required string AccessToken { get; set; }
}