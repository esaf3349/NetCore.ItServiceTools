using CommandsService.Application.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Threading.Tasks;
using System;

namespace CommandsService.Entry.WebApi.Middlewares
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
                case AlreadyExistsException alreadyExistsException:
                    code = HttpStatusCode.BadRequest;
                    result = alreadyExistsException.ToString();
                    break;
                case NotFoundException:
                    code = HttpStatusCode.NotFound;
                    break;
                case ValidationException validationException:
                    code = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.Failures);
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
