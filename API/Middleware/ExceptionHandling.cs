using System.Net;
using System.Text.Json;


public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next; // Call the function to process the next middleware 
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var response = context.Response;
        response.ContentType = "application/json";

        response.StatusCode = exception switch
        {
            InvalidCalculationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError

        };

        var payload = new
        {
            error = exception.GetType().Name,
            detail = exception.Message

        };
    }

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) //  Context = response + request
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
}