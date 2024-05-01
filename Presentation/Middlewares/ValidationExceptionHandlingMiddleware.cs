using Application.Abstractions.Exceptions;

namespace Presentation.Middlewares;

public class ValidationExceptionHandlingMiddleware(RequestDelegate next)
{

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ValidationException exception)
        {
            var details = new
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "ValidationError",
                Title = "Error de validación",
                Message = "Se han producido uno o mas errores.",
                Details = exception.Errors
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsJsonAsync(details);
        }
    }
}