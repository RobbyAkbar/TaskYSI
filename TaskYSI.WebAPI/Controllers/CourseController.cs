using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskYSI.Application.Common.Models;
using TaskYSI.Application.Course.Commands.CreateCourse;
using TaskYSI.Application.Course.Commands.DeleteCourse;
using TaskYSI.Application.Course.Commands.UpdateCourse;
using TaskYSI.Application.Course.Queries.GetCourseById;
using TaskYSI.Application.Course.Queries.GetCourseItemsWithPagination;
using TaskYSI.Application.Course.Queries.SearchCourseByName;
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
    public async Task<ActionResult<CourseResponse>> Create([FromForm] CreateCourseCommand request,
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
    [Authorize(Roles = "Student")]
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
    
    [HttpPut]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<IActionResult> UpdateCourse([FromForm] UpdateCourseRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Update Course API Calling in Controller... {@Request}", request);
        try
        {
            var response = await _mediator.Send(request, cancellationToken);
            _logger.LogInformation("Update Course Success {@Response}", response);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Update Course API Error Occur: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Delete Course By Id API Calling in Controller... Id: {id}");
            
            var query = new DeleteCourseCommand(id);
            await _mediator.Send(query, cancellationToken);
            return Results.NoContent();
        }
        catch (Exception ex)
        {
            _logger.LogError("Get Course By Id API Error Occurred: Message {@Message}", ex.Message);
            return Results.BadRequest(new { IsSuccess = false, ex.Message });
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CourseResponse>> GetCourseById(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Get Course By Id API Calling in Controller... Id: {id}");
            
            var query = new GetCourseByIdQuery(id);
            var response = await _mediator.Send(query, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Get Course By Id API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }

    [Route("Search")]
    [HttpGet]
    public async Task<ActionResult<List<SearchCourseResult>>> SearchCourseByName(
        [FromQuery] SearchCourseByNameQuery query, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Search Course By Name API Calling in Controller... Keyword: {query.Keyword}");

            var searchResult = await _mediator.Send(query, cancellationToken);
            return Ok(searchResult);
        }
        catch (Exception ex)
        {
            _logger.LogError("Search Course By Name API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
}