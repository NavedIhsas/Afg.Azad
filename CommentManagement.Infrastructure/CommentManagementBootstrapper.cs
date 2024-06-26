using _0_FrameWork.Domain.Infrastructure;
using CommentManagement.Application;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Application.Contract.HomePhoto;
using CommentManagement.Domain.CourseCommentAgg;
using CommentManagement.Domain.Notification.Agg;
using CommentManagement.Domain.SliderAgg;
using CommentManagement.Domain.VisitAgg;
using CommentManagement.Infrastructure.EfCore;
using CommentManagement.Infrastructure.EfCore.Repository;
using CommentManagement.Infrastructure.Permissions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Afg.Azad.UnQuery.Contract.Comment;
using Afg.Azad.UnQuery.Query;

namespace CommentManagement.Infrastructure
{
    public class CommentManagementBootstrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddScoped<ICommentRepository, CommentRepository>();
            service.AddScoped<ICommentApplication, CommentApplication>();
            service.AddScoped<ICommentQuery, CommandQuery>();

            service.AddScoped<IVisitRepository, VisitRepository>();

            service.AddScoped<INotificationRepository, NotificationRepository>();

            service.AddScoped<IPermissionExposer, CommentPermissionExposer>();

            service.AddScoped<ISliderApplication, SliderApplication>();
            service.AddScoped<ISliderRepository, SliderRepository>();

            service.AddDbContext<CommentContext>(option => { option.UseSqlServer(connectionString); });
        }
    }
}