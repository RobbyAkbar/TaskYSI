using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskYSI.Application.Commands.InsertModule;
using TaskYSI.Application.Queries.Module;
using TaskYSI.Domain.Models;
using TaskYSI.Domain.Models.Module;

namespace TaskYSI.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModuleController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ModuleController> _logger;

    public ModuleController(IMediator mediator, ILogger<ModuleController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<ActionResult<ModuleResponse>> Create([FromForm] InsertModuleCommand request,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Create Module API Calling in Controller... {@Request}", request);
        try
        {
            var response = await _mediator.Send(request, cancellationToken);
            _logger.LogInformation("Insert Module Success {@Response}", response);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Create Module API Error Occur: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ModuleResponse>>> GetModuleItemsWithPagination([FromQuery] GetModuleItemsWithPaginationQuery query, CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation($"Get Module API Calling in Controller: PageNumber {query.PageNumber}, PageSize {query.PageSize}");

            // Mengirim permintaan dengan parameter paginasi ke mediator
            var response = await _mediator.Send(query, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            _logger.LogError("Get Module API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
}