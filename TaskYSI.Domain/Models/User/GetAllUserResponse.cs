
namespace TaskYSI.Domain.Models.User;

public class GetAllUserResponse
{
    public int Total { get; set; }
    public required List<UserResponse> Data { get; set; }
}