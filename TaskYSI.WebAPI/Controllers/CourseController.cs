using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskYSI.Application.Commands.InsertCourse;
using TaskYSI.Application.Queries.Course;
using TaskYSI.Domain.Models;
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
    public async Task<ActionResult<PaginatedList<CourseResponse>>> GetCourseItemsWithPagination([FromQuery] GetCourseItemsWithPaginationQuery query, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Get Course API Calling in Controller: PageNumber {query.PageNumber}, PageSize {query.PageSize}");

            // Mengirim permintaan dengan parameter paginasi ke mediator
            var response = await _mediator.Send(query, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Get Course API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
}