using TaskYSI.Domain.Models.User;

namespace TaskYSI.Application.User.Queries.LoginUser;

public record LoginUserQuery(string Email, string Password) : IRequest<LoginUserResponse>;
