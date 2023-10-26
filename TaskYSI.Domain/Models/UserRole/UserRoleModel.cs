using TaskYSI.Domain.Models.User;

namespace TaskYSI.Domain.Models.UserRole;

public class UserRoleModel
{
    public int Id { get; set; }
    public required string RoleName { get; set; }
    public required ICollection<UserModel> Users { get; set; }
}