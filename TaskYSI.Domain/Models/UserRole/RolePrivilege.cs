namespace TaskYSI.Domain.Models.UserRole;

public class RolePrivilege
{
    public int Id { get; set; }
    public UserRoleModel UserRole { get; set; }
    public int? RoleId { get; set; }
    public string Privilege { get; set; }
}