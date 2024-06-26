using System.Security.Claims;
using ShopManagement.Domain;
using ShopManagement.Infrastructure.EfCore;

namespace WebHost.Utilities.Middleware;

public class UserActivityMiddleware
{
    private readonly RequestDelegate _next;

    public UserActivityMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context, ShopContext shopContext)
    {
        var area = context.Request;
        var isAdminPanel = area.Path.Value != null && area.Path.Value.StartsWith("/Administration");
        if (isAdminPanel)
        {
            var value = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (value != null)
            {
                var userId = long.Parse(value);
                var activity =await GetRequestData(context);

                if (context.Request.Method == HttpMethods.Post)
                {
                    var formData = await GetFormData(context.Request);
                    activity += $"\nForm Data: {formData}";
                }

                if (!string.IsNullOrWhiteSpace(activity))
                {
                    shopContext.UserActivities.Add(new UserActivity
                    {
                        Path = area.Path,
                        UserId = userId,
                        Activity = activity,
                        Method = area.Method,
                        Timestamp = DateTime.Now
                    });
                    await shopContext.SaveChangesAsync();
                }
            }

        }

        await _next(context);
    }

    private async Task<string> GetFormData(HttpRequest request)
    {
        // Read form data from the request
        var form = await request.ReadFormAsync();
        var formData = form.Select(pair => $"{pair.Key}={pair.Value}").ToList();
        return string.Join(", ", formData);
    }

    private  Task<string> GetRequestData(HttpContext context)
    {
      return Task.FromResult(GetQueryStringData(context.Request.Query));

    }

    private string GetQueryStringData(IQueryCollection query)
    {
        var queryStringData = query.Select(pair => $"{pair.Key}={pair.Value}").ToList();
        return string.Join(", ", queryStringData);
    }

}