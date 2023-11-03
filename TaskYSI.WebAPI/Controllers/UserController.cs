using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskYSI.Application.Common.Models;
using TaskYSI.Application.User.Commands.CreateUser;
using TaskYSI.Application.User.Commands.CreateUserRole;
using TaskYSI.Application.User.Queries.GetUserByEmail;
using TaskYSI.Application.User.Queries.GetUsersWithPagination;
using TaskYSI.Application.User.Queries.LoginUser;
using TaskYSI.Application.User.Queries.VerifiedUserEmail;
using TaskYSI.Application.UserRole.Queries.GetUserRoleItems;
using TaskYSI.Domain.Models.User;
using TaskYSI.Domain.Models.UserRole;

namespace TaskYSI.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(ISender mediator, ILogger<UserController> logger) : ControllerBase
{
    [Route("CreateUserRole")]
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<ActionResult<UserRoleResponse>> Create([FromForm] CreateUserRoleCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Create User Role API Calling in Controller... {@Request}", request);
        try
        {
            var response = await mediator.Send(request, cancellationToken);
            logger.LogInformation("Insert User Role Success {@Response}", response);
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError("Create User Role API Error Occur: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }

    [Route("GetUserRoles")]
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<List<UserRoleResponse>>> GetUserRoles(CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Get User Role API Calling in Controller...");
            var response = await mediator.Send(new GetUserRoleItemsQuery(), cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError("Get User Role API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }

    [HttpPost]
    [AllowAnonymous]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<ActionResult<UserResponse>> Create([FromForm] CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Create User API Calling in Controller... {@Request}", request);
        try
        {
            var response = await mediator.Send(request, cancellationToken);
            logger.LogInformation("Insert User Success {@Response}", response);
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError("Create User API Error Occur: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<PaginatedList<UserResponse>>> GetUsersWithPagination(
        [FromQuery] GetUsersWithPaginationQuery query, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation(
                "Get Users API Calling in Controller: PageNumber {PageNumber}, PageSize {PageSize}", query.PageNumber,
                query.PageSize);

            // Mengirim permintaan dengan parameter paginasi ke mediator
            var response = await mediator.Send(query, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError("Get Users API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }

    [Route("Search")]
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<ActionResult<UserResponse>> GetByEmail([FromForm] GetUserByEmailQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation(
                "Get User by Email API Calling in Controller...");

            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError("Get User by Email API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }

    [Route("VerifiedEmail")]
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<UserResponse>> VerifiedUserEmail([FromQuery] VerifiedUserEmailQuery query,
        CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Verified Email API Calling in Controller...");
            var response = await mediator.Send(query, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError("Verified Email API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
    
    [AllowAnonymous]
    [Route("Login")]
    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<ActionResult<LoginUserResponse>> Login([FromForm] LoginUserQuery request, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Login User API Calling in Controller...");
            var response = await mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError("Login User API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
}