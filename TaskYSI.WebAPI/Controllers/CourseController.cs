using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskYSI.Application.Commands;
using TaskYSI.Domain.Models.Course;

namespace TaskYSI.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CourseController> _logger;

    public CourseController(IMediator mediator, ILogger<CourseController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<ActionResult<CourseResponse>> Create([FromForm] InsertCourseCommand request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Create Course API Calling in Controller... {@Request}", request);
        try
        {
            var response = await _mediator.Send(request, cancellationToken);
            _logger.LogInformation("Insert Course Success {@Response}", response);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Create Course API Error Occur: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<List<GetAllCourseResponse>>> GetAll(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("GetAll Course API Calling in Controller...");
            var response = await _mediator.Send(new GetAllCourseCommand(), cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("GetAll Course API Error Occur: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
}