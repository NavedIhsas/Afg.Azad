using Azure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Threading.Tasks;

namespace WebHost.Utilities.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SetDefaultLan
    {
        private readonly RequestDelegate _next;

        public SetDefaultLan(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.HasFormContentType)
            {
                Task<IFormCollection> form;
                form = Task.FromResult(httpContext.Request.Form); // sync
                // Or
                form =  httpContext.Request.ReadFormAsync(); // async

            }
            var cookie = httpContext.Request.Cookies[".AspNetCore.Culture"];
            if (cookie != null)
                return _next(httpContext);

            httpContext.Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture("prs")),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );


            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SetDefaultLanExtensions
    {
        public static IApplicationBuilder UseSetDefaultLan(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SetDefaultLan>();
        }
    }
}
