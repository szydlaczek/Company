using CompanySelf.Application.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CompanySelf.Api.Core
{
    public class ApiExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ApiExceptionMiddleware> _logger;

        public ApiExceptionMiddleware(RequestDelegate next,
                                      ILogger<ApiExceptionMiddleware> logger)
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

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string result;
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            if (exception is NotFoundException)
            {
                result = new ErrorResponse() { Message = exception.Message }.ToString();
            }
            else
            {
                result = new ErrorResponse() { Message = "Something goes wrong" }.ToString();
            }

            _logger.LogError($"Something went wrong: {exception.Message}");
            return context.Response.WriteAsync(result);
        }
    }
}