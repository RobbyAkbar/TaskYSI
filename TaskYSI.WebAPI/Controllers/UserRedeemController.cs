using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskYSI.Application.UserCourse.Commands.CreateUserCourse;
using TaskYSI.Application.UserCourse.Queries.GetUserCourse;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.WebAPI.Controllers;

[Route("api/Course/[controller]")]
[ApiController]
public class UserRedeemController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<UserRedeemController> _logger;

    public UserRedeemController(IMediator mediator, ILogger<UserRedeemController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<ActionResult<UserCourseResponse>> Create([FromForm] CreateUserCourseCommand request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Create User Course API Calling in Controller... {@Request}", request);
        try
        {
            var response = await _mediator.Send(request, cancellationToken);
            _logger.LogInformation("Insert User Course Success {@Response}", response);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Create User Course API Error Occur: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<UserCourseResponse>> GetUserCourse([FromQuery] GetUserCourseQuery query,
        CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("GetUserCourse API Calling in Controller...");
            var response = await _mediator.Send(query, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("GetUserCourse API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
}