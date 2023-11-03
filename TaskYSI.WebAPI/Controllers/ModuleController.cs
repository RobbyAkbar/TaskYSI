using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskYSI.Application.Common.Models;
using TaskYSI.Application.Module.Commands.CreateModule;
using TaskYSI.Application.Module.Queries.GetModuleItemsWithPagination;
using TaskYSI.Domain.Models.Module;

namespace TaskYSI.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ModuleController(ISender mediator, ILogger<ModuleController> logger) : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Admin,Teacher")]
    [Consumes("application/x-www-form-urlencoded")]
    public async Task<ActionResult<ModuleResponse>> Create([FromForm] CreateModuleCommand request,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("Create Module API Calling in Controller... {@Request}", request);
        try
        {
            var response = await mediator.Send(request, cancellationToken);
            logger.LogInformation("Insert Module Success {@Response}", response);
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError("Create Module API Error Occur: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
    
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<PaginatedList<ModuleResponse>>> GetModuleItemsWithPagination([FromQuery] GetModuleItemsWithPaginationQuery query, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation($"Get Module API Calling in Controller: PageNumber {query.PageNumber}, PageSize {query.PageSize}");

            // Mengirim permintaan dengan parameter paginasi ke mediator
            var response = await mediator.Send(query, cancellationToken);
            return Ok(response);
        }
        catch (Exception ex)
        {
            logger.LogError("Get Module API Error Occurred: Message {@Message}", ex.Message);
            return BadRequest(new { IsSuccess = false, ex.Message });
        }
    }
}