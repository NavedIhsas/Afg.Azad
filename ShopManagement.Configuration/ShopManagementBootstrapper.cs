using System;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Afg.Azad.UnQuery.Contract.Course;
using Afg.Azad.UnQuery.Contract.CourseGroup;
using Afg.Azad.UnQuery.Contract.Forum.Question;
using Afg.Azad.UnQuery.Query;
using AutoMapper;
using Shop.Management.Application.Contract.Course;
using Shop.Management.Application.Contract.CourseEpisode;
using Shop.Management.Application.Contract.CourseGroup;
using Shop.Management.Application.Contract.CourseLevel;
using Shop.Management.Application.Contract.CourseStatus;
using Shop.Management.Application.Contract.OnlineCourse;
using Shop.Management.Application.Contract.Order;
using Shop.Management.Application.Contract.Quiz;
using Shop.Management.Application.Contract.ToBeLearn;
using ShopManagement.Application;
using ShopManagement.Domain.CourseAgg;
using ShopManagement.Domain.CourseEpisodeAgg;
using ShopManagement.Domain.CourseGroupAgg;
using ShopManagement.Domain.CourseLevelAgg;
using ShopManagement.Domain.CourseStatusAgg;
using ShopManagement.Domain.OrderAgg;
using ShopManagement.Domain.OrderDetailAgg;
using ShopManagement.Domain.ToBeLearn;
using ShopManagement.Infrastructure.EfCore;
using ShopManagement.Infrastructure.EfCore.Repository;
using ShopManagement.Infrastructure.EfCore.VisitorOnline;
using ShopManagement.Infrastructure.EfCore.Visitors.GetTodayReport;
using ShopManagement.Infrastructure.EfCore.Visitors.SaveVisitorInfo;
using GetTodayReport = ShopManagement.Infrastructure.EfCore.Repository.GetTodayReport;
using ShopManagement.Configuration.Permission;
using ShopManagement.Domain.OnlineCourse;
using ShopManagement.Domain.Quiz;
using System.Reflection;
using _0_Framework.Application;
using Afg.Azad.UnQuery.Contract.Quiz;
using Shop.Management.Application.Contract.Language;
using Shop.Management.Application.Contract.UserCourse;
using ShopManagement.Domain.LanguageAgg;
using ShopManagement.Domain.UserCoursesAgg;

namespace ShopManagement.Configuration
{
    public class ShopMapper : Profile
    {
        public ShopMapper()
        {
            CreateMap<Quiz, EditQuiz>().ForMember(x => x.Time, opt => opt.MapFrom(x => x.OnDate.ToString("HH:mm:ss")));

            CreateMap<Quiz, QuestionViewModel>();

            CreateMap<Quiz, QuizViewModel>()
                .ForMember(x => x.CreationDate, opt => opt.MapFrom(x => x.CreationDate.ToFarsi()))
                .ForMember(x => x.OnDate, opt => opt.MapFrom(x => x.OnDate.ToShamsi()))

                .ForMember(x => x.Time, opt => opt.MapFrom(x => x.OnDate.ToString("HH:mm:ss")))

                .ForMember(x => x.PeriodTime, opt => opt.MapFrom(x => x.PeriodTime))


                .ForMember(x => x.Status, opt => opt.MapFrom(x => x.QuizStatus.GetDisplayName()));

            CreateMap<Quiz, QuizQueryModel>().ForMember(x => x.CreationDate, opt => opt.MapFrom(x => x.CreationDate.ToFarsi())).ForMember(x => x.OnDatePersian, opt => opt.MapFrom(x => x.OnDate.ToShamsi())).ForMember(x => x.Status, opt => opt.MapFrom(x => x.QuizStatus.GetDisplayName()));
            CreateMap<Question, EditQuestion>();
            CreateMap<Question, QuestionViewModel>();
            CreateMap<UserCourseInfo, UserCourseInfoDto>().ReverseMap();

        }
    }

    public class ShopManagementBootstrapper
    {


        public static void Configure(IServiceCollection service, string connection)
        {
            service.AddScoped<ICourseGroupApplication, CourseGroupApplication>();
            service.AddScoped<ICourseGroupRepository, CourseGroupRepository>();

            service.AddScoped<ICourseApplication, CourseApplication>();
            service.AddScoped<ICourseRepository, CourseRepository>();

            service.AddScoped<ICourseStatusApplication, CourseStatusApplication>();
            service.AddScoped<ICourseStatusRepository, CourseStatusRepository>();

            service.AddScoped<ICourseLevelApplication, CourseLevelApplication>();
            service.AddScoped<ICourseLevelRepository, CourseLevelRepository>();

            service.AddScoped<ICourseQuery, CourseQuery>();

            service.AddScoped<ICourseGroupQuery, CourseGroupQuery>();


            service.AddScoped<ICourseEpisodeApplication, CourseEpisodeApplication>();
            service.AddScoped<ICourseEpisodeRepository, CourseEpisodeRepository>();

            service.AddScoped<IOrderRepository, OrderRepository>();
            service.AddScoped<IOrderApplication, OrderApplication>();

            service.AddScoped<IToBeLeanApplication, ToBeLearnApplication>();
            service.AddScoped<IToBeLeanRepository, ToBeLearnRepository>();

            service.AddScoped<IOnlineCourseApplication, OnlineCourseApplication>();
            service.AddScoped<IOnlineCourseRepository, OnlineCourseRepository>();

            service.AddScoped<IQuizApplication, QuizApplication>();
            service.AddScoped<IQuizRepository, QuizRepository>();
            service.AddScoped<IQuizQuery, QuizQuery>();

            service.AddScoped<IQuestionApplication, QuestionApplication>();
            service.AddScoped<IQuestionRepository, QuestionRepository>();

              service.AddScoped<ILanguageApplication, LanguageApplication>();
            service.AddScoped<ILanguageRepository, LanguageRepository>();

            service.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

            service.AddScoped<IPermissionExposer, ShopPermissionExposer>();
            //service.AddScoped<IForumQuery, ForumQuery>();
            service.AddScoped<IVisitorOnlineService, VisitorOnlineService>();
            service.AddScoped<ISaveVisitorInfoService, SaveVisitorInfoService>();
            service.AddScoped<IGetTodayReport, GetTodayReport>();

            service.AddScoped<IUserCourseInfoApplication, UserCourseInfoApplication>();
            service.AddScoped<IUserCourseInfoRepository, UserCourseInfoRepository>();

            service.AddScoped<IRegisterCourseQuery, RegisterCourseQuery>();
            service.AddAutoMapper(typeof(ShopMapper));
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddDbContext<ShopContext>(option => { option.UseSqlServer(connection); });
        }
    }
}