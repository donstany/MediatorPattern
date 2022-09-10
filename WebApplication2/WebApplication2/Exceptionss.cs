using System.Net;
using System.Text.Json;

namespace MediatRDemoAPI
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="correlationContextAccessor"></param>
        public CustomExceptionHandlerMiddleware(RequestDelegate next)
            => _next = next;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
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

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            //if (exception is ValidationException)
            //{
            //    Log.Error(
            //        "Validation exception with request correlation Id: {@CorrelationId} and result:\n\r{failures}",
            //        ((ValidationException)exception).Failures
            //    );
            //}
            //else
            //{
            //    Log.Error(exception, "Request with correlation Id: {@CorrelationId} failed.", _correlationContextAccessor.CorrelationContext.CorrelationId);
            //}


            var result = string.Empty;
            HttpStatusCode code;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.Failures);
                    break;
                //case NotFoundException _:
                //    code = HttpStatusCode.NotFound;
                //    result = JsonSerializer.Serialize(new { error = exception.Message });
                //    break;
                //case BadRequestException _:
                //    code = HttpStatusCode.BadRequest;
                //    break;
                //case UnauthorizedException _:
                //    code = HttpStatusCode.Unauthorized;
                //    break;
                //case ForbiddenException _:
                //    code = HttpStatusCode.Forbidden;
                //    break;
                //case ConflictException _:
                //    code = HttpStatusCode.Conflict;
                //    break;
                default:
                    code = HttpStatusCode.InternalServerError;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}
