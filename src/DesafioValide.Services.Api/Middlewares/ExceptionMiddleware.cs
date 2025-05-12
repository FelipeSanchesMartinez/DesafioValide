using FluentValidation;
using DesafioValide.Domain.Response;
using DesafioValide.Domain.Notifications;

namespace DesafioValide.Services.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                await HandleValidationExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleValidationExceptionAsync(HttpContext context, ValidationException? ex)
        {
            var payload = ApiResult.ErrorResult(null, 400,
                ex!.Errors.Select(err => new DomainNotification("Validation", err.ErrorMessage)).ToArray());

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            return context.Response.WriteAsJsonAsync(payload);
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var payload = ApiResult.ErrorResult(null, 500, new DomainNotification("InternalServerError", ex.Message));

            context.Response.StatusCode = payload.Status;

            return context.Response.WriteAsJsonAsync(payload);

        }
    }
}
