namespace Presentation.Middlewares;

public class CustomExceptionHandlingMiddleware(RequestDelegate next)
{

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception exception)
        {
            var details = new
            {
                Status = StatusCodes.Status400BadRequest,
                Type = exception.GetType().ToString(),
                Title = "",
                Detail = exception.Message
            };

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsJsonAsync(details);
        }
    }

}