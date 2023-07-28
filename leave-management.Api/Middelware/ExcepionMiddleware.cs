using leave_management.Api.Middelware.Models;
using leave_management.Application.Exceptions;
using SendGrid.Helpers.Errors.Model;
using System.Net;

namespace leave_management.Api.Middelware
{
    public class ExcepionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExcepionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleException(context, ex);
            }
        }

        private async Task HandleException(HttpContext context, Exception ex)
        {
            HttpStatusCode statusCode= HttpStatusCode.InternalServerError;
            CostomValidatorsProblemDetails problem = new();
            switch (ex)
            {
                case Application.Exceptions.BadRequestExceptions badHttpRequest:
                    statusCode = HttpStatusCode.BadRequest;
                    problem = new CostomValidatorsProblemDetails
                    {
                       Title = badHttpRequest.Message,
                       Status = (int)statusCode,
                       Detail = badHttpRequest.InnerException?.Message,
                       Type  = nameof(BadHttpRequestException),
                       Erros = badHttpRequest.ValidationErrors
                    };
                    break;
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    problem = new CostomValidatorsProblemDetails
                    {
                        Title = notFoundException.Message,
                        Status = (int)statusCode,
                        Detail = notFoundException.InnerException?.Message,
                        Type = nameof(NotFoundException)
                    };
                    break;
                default:
                    problem = new CostomValidatorsProblemDetails
                    {
                        Title = ex.Message,
                        Status = (int)statusCode,
                        Detail = ex.StackTrace,
                        Type = nameof(HttpStatusCode.InternalServerError)
                    };
                    break;
            }
            context.Response.StatusCode = (int)statusCode;
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
