namespace YetAnotherStore.Api.Middlewares;

// You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
public class ExceptionHandlingMiddleware(
    RequestDelegate next,
    ILogger<ExceptionHandlingMiddleware> logger
)
{
    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred during handling of an exception");

            if (ex.InnerException is null)
            {
                return;
            }

            logger.LogError(ex.InnerException, "There is an Inner Exception");
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(
                new
                {
                    Message = "An error has occurred. Please contact the Webmaster.",
                    Type = "Internal Server Error",
                }
            );
        }
    }
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionHandlingMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(
        this IApplicationBuilder builder
    )
    {
        return builder.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
