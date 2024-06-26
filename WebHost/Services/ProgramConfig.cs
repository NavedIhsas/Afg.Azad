using System.Globalization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using _0_Framework.Application;
using _0_FrameWork.Application;
using _0_Framework.Application.ZarinPal;
using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Infrastructure;
using Afg.Azad.UnQuery.Contract;
using Afg.Azad.UnQuery.Query;
using BlogManagement.Infrastructure;
using CommentManagement.Infrastructure;
using DiscountManagement.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using ShopManagement.Configuration;
using WebHost.Utilities.Filters;
using WebHost.Utilities.Filters.Permission;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.ResponseCompression;
using Serilog;
using Serilog.Formatting.Compact;
using WebMarkupMin.AspNetCore7;

namespace WebHost.Services
{
    [IgnoreAntiforgeryToken]
    public static class ProgramConfig
    {
        public static void Configure(this IServiceCollection services, string connectionString)
        {

            services.AddRazorPages().AddMvcOptions(option =>
            {
                option.Filters.Add<SaveVisitorFilter>();
                option.Filters.Add<Security>();
            }).AddRazorPagesOptions(opts =>
            {
                opts.Conventions.AuthorizeAreaFolder("Administration", "/", "Administration");
                // opts.Conventions.AuthorizeAreaFolder("UserPanel", "/", "UserPanel");

            });
            services.AddSignalR();


         
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 200 * 1024 * 1024;
            });
            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = 209715200;
            });
        

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Login");
                    o.LogoutPath = new PathString("/SignUp");
                    o.AccessDeniedPath = new PathString("/Error");
                    o.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
                });
            services.AddLogging();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddHttpClient();
            #region For Seo

            //minify html
            services.AddWebMarkupMin(options =>
            {
                //options.AllowCompressionInDevelopmentEnvironment = true;
                options.AllowMinificationInDevelopmentEnvironment = true;

            }).AddHtmlMinification(options =>
            {
                options.MinificationSettings.RemoveHtmlComments = true;
                options.MinificationSettings.RemoveHtmlCommentsFromScriptsAndStyles = true;
                options.MinificationSettings.RemoveHttpProtocolFromAttributes = true;
                options.MinificationSettings.RemoveHttpsProtocolFromAttributes = true;
                options.MinificationSettings.RemoveOptionalEndTags = true;
                options.MinificationSettings.RemoveTagsWithoutContent = true;
                options.MinificationSettings.MinifyEmbeddedCssCode = true;
                options.MinificationSettings.MinifyEmbeddedJsCode = true;
                options.MinificationSettings.MinifyInlineCssCode = true;
                options.MinificationSettings.MinifyInlineJsCode = true;
                options.MinificationSettings.MinifyInlineJsCode = true;
            });

            services.AddControllersWithViews();

            //for stay login
            services.AddDataProtection();

            //for gzip
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = System.IO.Compression.CompressionLevel.Optimal;
            });

            services.AddResponseCompression(options =>
            {
                options.EnableForHttps = true;
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    "image/svg+xml",
                    "application/atom+xml",
                    // General
                    "text/plain",
                    // Static files
                    "text/css",
                    "application/javascript",
                    // MVC
                    "text/html",
                    "application/xml",
                    "text/xml",
                    "application/json",
                    "text/json",
                });
            });



            #endregion

            #region IOC
            services.AddHttpContextAccessor();
            services.AddScoped<IFileUploader, FileUploader>();
            services.AddScoped<IEpisodeFileUploader, EpisodeUploadFile>();
            services.AddScoped<IAuthHelper, AuthHelper>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IPermissionExpose, PermissionExpose>();
            services.AddScoped<IZarinPalFactory, ZarinPalFactory>();
            services.AddScoped<IRazorPartialToStringRenderer, RazorPartialToStringRenderer>();
            services.AddScoped<IEpisodeFileUploader, EpisodeUploadFile>();
            services.AddScoped<ILanguageQuery, LanguageQuery>();
            services.AddLocalization();
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            services.AddHttpContextAccessor();
            ShopManagementBootstrapper.Configure(services, connectionString);
            BlogManagementBootstrapper.Configure(services, connectionString);
            CommentManagementBootstrapper.Configure(services, connectionString);
            DiscountManagementBootstrapper.Configure(services, connectionString);
            AccountManagementBootstrapper.Configure(services, connectionString);
            #endregion
            services.AddAuthorization(option =>
            {
                var roles = new List<string>
                {
                      Roles.Administrator.ToString(), Roles.Admin.ToString(), Roles.Blogger.ToString(), Roles.Teacher.ToString(), Roles.NoAuthorize.ToString(), Roles.Manager.ToString()

                };
                option.AddPolicy("Administration", role => role
                    .RequireRole(roles));

                option.AddPolicy("Courses", builder => builder
                    .RequireRole(roles));

                option.AddPolicy("Accounts", builder => builder
                    .RequireRole(roles));

                option.AddPolicy("Blog", builder => builder
                    .RequireRole(roles));

                option.AddPolicy("Comment", builder => builder
                    .RequireRole(roles));

                option.AddPolicy("Discount", builder => builder
                    .RequireRole(roles));

                option.AddPolicy("News", builder => builder
                    .RequireRole(roles));

                option.AddPolicy("Quiz", builder => builder
                    .RequireRole(roles));

                option.AddPolicy("Slider", builder => builder
                    .RequireRole(roles));
            });

            services.AddRazorPages().AddRazorPagesOptions(option =>
            {
                option.Conventions.AuthorizeAreaFolder("Administration", "/", "Administration");
                  option.Conventions.AuthorizeAreaFolder("Administration", "/Accounts", "Accounts");
                  option.Conventions.AuthorizeAreaFolder("Administration", "/Blog", "Blog");
                  option.Conventions.AuthorizeAreaFolder("Administration", "/Comment", "Comment");
                  option.Conventions.AuthorizeAreaFolder("Administration", "/Discount", "Discount");
                  option.Conventions.AuthorizeAreaFolder("Administration", "/News", "News");
                  option.Conventions.AuthorizeAreaFolder("Administration", "/Quiz", "Quiz");
                  option.Conventions.AuthorizeAreaFolder("Administration", "/Slider", "Slider");
                  option.Conventions.AuthorizeAreaFolder("Administration", "/Courses", "Courses");
            });
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
        }
    }
}
