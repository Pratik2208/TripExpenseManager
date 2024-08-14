namespace TripExpenseManager.API.ExceptionHandling
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger, RequestDelegate next)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
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

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            int statusCode = ex switch
            {
                ArgumentNullException => statusCode = StatusCodes.Status400BadRequest,
                InvalidOperationException => statusCode = StatusCodes.Status409Conflict,
                Exception => statusCode = StatusCodes.Status500InternalServerError
            };

            var errorResponse = new ErrorResponse
            {
                StatusCode = statusCode,
                Message = ex.Message
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsync(errorResponse.ToString());
        }
    }

    public static class ApplicationBuilderExtension
    {
        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
        }
    }
}
