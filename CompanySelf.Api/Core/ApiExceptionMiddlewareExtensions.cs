using Microsoft.AspNetCore.Builder;

namespace CompanySelf.Api.Core
{
    public static class ApiExceptionMiddlewareExtensions
    {
        public static void UseApiException(this IApplicationBuilder app)
        {
            app.UseMiddleware<ApiExceptionMiddleware>();
        }
    }
}