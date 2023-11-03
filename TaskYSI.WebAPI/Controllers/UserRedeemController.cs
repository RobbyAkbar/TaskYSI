using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskYSI.Application.UserCourse.Commands.CreateUserCourse;
using TaskYSI.Application.UserCourse.Queries.GetUserCourse;
using TaskYSI.Domain.Models.User;

namespace TaskYSI.WebAPI.Controllers;

[Route("api/Course/[controller]")]
[ApiController]
public class UserRedeemController(ISender mediator, ILogger<UserRedeemController> logger) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Student")]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<ActionResult<UserCourseResponse>> Create([FromForm] CreateUserCourseCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Create User Course API Calling in Controller... {@Request}", request);
        try
        {
            var response = await mediator.Send(request, cancellationToken);
            logger.LogInformation("Insert User Course Success {@Response}", response);
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError("Create User Course API Error Occur: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
    
    [HttpGet]
    [Authorize(Roles = "Student")]
    public async Task<ActionResult<UserCourseResponse>> GetUserCourse([FromQuery] GetUserCourseQuery query,
        CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("GetUserCourse API Calling in Controller...");
            var response = await mediator.Send(query, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError("GetUserCourse API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
}