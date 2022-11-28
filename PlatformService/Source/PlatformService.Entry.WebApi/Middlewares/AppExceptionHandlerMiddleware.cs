using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using PlatformService.Application.Common.Exceptions;
using System.Net;
using Newtonsoft.Json;

namespace PlatformService.Entry.WebApi.Middlewares
{
    public class AppExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public AppExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleAsync(context, ex);
            }
        }

        private static Task HandleAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.Failures);
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            if (result == string.Empty)
                result = JsonConvert.SerializeObject(new { error = exception.Message });

            return context.Response.WriteAsync(result);
        }
    }
}
