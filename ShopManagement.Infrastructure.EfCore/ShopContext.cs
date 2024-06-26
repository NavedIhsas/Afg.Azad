using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.CourseAgg;
using ShopManagement.Domain.CourseEpisodeAgg;
using ShopManagement.Domain.CourseGroupAgg;
using ShopManagement.Domain.CourseLevelAgg;
using ShopManagement.Domain.CourseStatusAgg;
using ShopManagement.Domain.ForumAgg;
using ShopManagement.Domain.OnlineCourse;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.OrderDetailAgg;
using ShopManagement.Domain.Quiz;
using ShopManagement.Domain.ToBeLearn;
using ShopManagement.Domain.UserCoursesAgg;
using ShopManagement.Domain.Visitors;
using ShopManagement.Infrastructure.EfCore.Mapping;
using System.Linq;
using ShopManagement.Domain;
using ShopManagement.Domain.LanguageAgg;

namespace ShopManagement.Infrastructure.EfCore
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        public DbSet<CourseGroup> CourseGroups { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseLevel> CourseLevels { get; set; }
        public DbSet<CourseStatus> CourseStatus { get; set; }
        public DbSet<CourseEpisode> CourseEpisodes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<UserCourse> UserCourses { get; set; }
        public DbSet<OnlineCourse> OnlineCourses { get; set; }
       // public DbSet<ForumQuestion> ForumQuestions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<OnlineVisitors> OnlineVisitors { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<VisitorVersion> VisitorVersions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
        public DbSet<ShopManagement.Domain.Quiz.Question> Questions { get; set; }
        public DbSet<UserResult> UserResults { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<UserCourseInfo> UserCourseInfo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("dbo");
            var assembly = typeof(CourseGroupMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}