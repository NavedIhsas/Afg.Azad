using System.Net;
using System.Net.Mime;
using System.Text.Json;
using Serilog;

namespace WebHost.Utilities.Middleware;
/// <summary>
/// کانفیگ اکسپشن ها
/// </summary>
public class ExceptionMiddleware
{
    private readonly IHostEnvironment _environment;
    private readonly RequestDelegate _next;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="environment"></param>
    /// <param name="next"></param>
    public ExceptionMiddleware(IHostEnvironment environment, RequestDelegate next)
    {
        _environment = environment;
        _next = next;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message, LogLevel.Error);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var trace = ex.StackTrace;
        if (trace != null)
        {
            var response = _environment.IsDevelopment();
            var json = JsonSerializer.Serialize(response);
            await context.Response.WriteAsync(json);
        }
    }
}