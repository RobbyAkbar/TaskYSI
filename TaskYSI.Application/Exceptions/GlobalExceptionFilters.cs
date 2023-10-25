using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace TaskYSI.Application.Exceptions;

public class GlobalExceptionFilters : IExceptionFilter
{
    private readonly ILogger _logger;


    public GlobalExceptionFilters(ILogger logger)
    {
        _logger = logger;
    }
    
    public void OnException(ExceptionContext context)
    {
        if (context.ExceptionHandled) return;
        var exception = context.Exception;

        var statusCode = true switch
        {
            bool when exception is UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
            bool when exception is InvalidOperationException => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError
        };

        _logger.LogError($"GlobalExceptionFilter: Error in {context.ActionDescriptor.DisplayName}. {exception.Message}. Stack Trace: {exception.StackTrace}");


        // Custom Exception message to be returned to the UI
        context.Result = new ObjectResult(exception.Message) { StatusCode = statusCode };
    }
}
