using Microsoft.AspNetCore.Mvc.Filters;
using TaskYSI.Infrastructure.Context;
using TaskYSI.WebAPI.Exceptions;

namespace TaskYSI.WebAPI.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _privilege;

    public AuthorizeAttribute(string privilege = "")
    {
        _privilege = privilege;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
        if (allowAnonymous) return;

        var roleId = context.HttpContext.Items["RoleId"];
        if (roleId == null)
            throw new UnauthorizedException();

        var db = context.HttpContext.RequestServices.GetService(typeof(IDatabaseContext)) as IDatabaseContext;

        if (!ValidatePrivilege(Convert.ToInt32(roleId), db))
            throw new ForbiddenException();
    }

    private bool ValidatePrivilege(int? roleId, IDatabaseContext? db)
    {
        if (roleId == null || db == null) return false;

        var roleExist = db.UserRoles.Any(x => x.Id == roleId);
        if (!roleExist) return false;

        if (string.IsNullOrWhiteSpace(_privilege)) return true;
        
        return db.RolePrivileges
            .Any(x => x.RoleId == roleId && x.Privilege == _privilege);
    }
}