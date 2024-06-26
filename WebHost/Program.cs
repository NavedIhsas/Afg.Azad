using Microsoft.AspNetCore.DataProtection;
using Serilog;
using WebHost.Hubs;
using WebHost.Services;
using WebHost.Utilities.Middleware;
using AspNetCore.ReCaptcha;
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .CreateLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);
    var env = builder.Environment;

    builder.Host.UseSerilog().ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.SetMinimumLevel(LogLevel.Trace);
    });


    var configuration = builder.Configuration;
    Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

    var connectionString = configuration.GetConnectionString("AfgAzadUnConnection");

    builder.Services.Configure(connectionString);
    builder.Services.AddReCaptcha(configuration.GetSection("ReCaptcha"));
    builder.Services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(Directory.GetCurrentDirectory())).SetDefaultKeyLifetime(TimeSpan.FromDays(30));

    var app = builder.Build();
    //if (app.Environment.IsDevelopment())
    //{
    //   // app.UseExceptionHandler("/Error");
    //    app.UseDeveloperExceptionPage();
    //    //app.UseHsts();
    //}
    app.Use(async (context, next) =>
    {
        if (context.Request.Path.StartsWithSegments("/robots.txt"))
        {
            var robotsTxtPath = Path.Combine(env.ContentRootPath, "robots.txt");
            string output = "User-agent: * allow: /";
            if (File.Exists(robotsTxtPath))
            {
                output = await File.ReadAllTextAsync(robotsTxtPath);
            }
            context.Response.ContentType = "text/plain";
            await context.Response.WriteAsync(output);
        }
        else await next();
    });
    app.UseCors();
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseSetVisitorId();
    app.UseAuthentication();
    app.UseCookiePolicy();
    app.UseAuthorization();
    app.UseMiddleware<UserActivityMiddleware>();
    app.UseMiddleware<ExceptionMiddleware>();
    app.MapRazorPages();
    app.MapHub<OnlineVisitorHub>("/chathub");
    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "اجرای اپلیکشن با خطا  مواجه شد.");
}
finally
{
    Log.CloseAndFlush();
}