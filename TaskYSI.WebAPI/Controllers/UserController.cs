using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskYSI.Application.User.Commands.CreateUser;
using TaskYSI.Application.User.Commands.CreateUserRole;
using TaskYSI.Application.User.Queries.GetUserByEmail;
using TaskYSI.Application.User.Queries.GetUsersWithPagination;
using TaskYSI.Application.User.Queries.VerifiedUserEmail;
using TaskYSI.Application.UserRole.Queries.GetUserRoleItems;
using TaskYSI.Domain.Models;
using TaskYSI.Domain.Models.User;
using TaskYSI.Domain.Models.UserRole;
using TaskYSI.WebAPI.Attributes;

namespace TaskYSI.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserController> _logger;

    public UserController(IMediator mediator, ILogger<UserController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [Route("CreateUserRole")]
    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<ActionResult<UserRoleResponse>> Create([FromForm] CreateUserRoleCommand request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Create User Role API Calling in Controller... {@Request}", request);
        try
        {
            var response = await _mediator.Send(request, cancellationToken);
            _logger.LogInformation("Insert User Role Success {@Response}", response);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Create User Role API Error Occur: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }

    [Route("GetUserRoles")]
    [HttpGet]
    public async Task<ActionResult<List<UserRoleResponse>>> GetUserRoles(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Get User Role API Calling in Controller...");
            var response = await _mediator.Send(new GetUserRoleItemsQuery(), cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Get User Role API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }

    [AllowAnonymous]
    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<ActionResult<UserResponse>> Create([FromForm] CreateUserCommand request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Create User API Calling in Controller... {@Request}", request);
        try
        {
            var response = await _mediator.Send(request, cancellationToken);
            _logger.LogInformation("Insert User Success {@Response}", response);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Create User API Error Occur: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<UserResponse>>> GetUsersWithPagination(
        [FromQuery] GetUsersWithPaginationQuery query, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation(
                "Get Users API Calling in Controller: PageNumber {PageNumber}, PageSize {PageSize}", query.PageNumber,
                query.PageSize);

            // Mengirim permintaan dengan parameter paginasi ke mediator
            var response = await _mediator.Send(query, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Get Users API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }

    [Route("Search")]
    [HttpPost]
    public async Task<ActionResult<UserResponse>> GetByEmail([FromForm] GetUserByEmailQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation(
                "Get User by Email API Calling in Controller...");

            var response = await _mediator.Send(request, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Get User by Email API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }

    [Route("VerifiedEmail")]
    [HttpGet]
    public async Task<ActionResult<UserResponse>> VerifiedUserEmail([FromQuery] VerifiedUserEmailQuery query,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("Verified Email API Calling in Controller...");
            var response = await _mediator.Send(query, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Verified Email API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
}