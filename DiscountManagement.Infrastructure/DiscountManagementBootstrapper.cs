using _0_FrameWork.Domain.Infrastructure;
using ColleagueDiscountManagementApplication.Contract.ColleagueDiscount;
using ColleagueDiscountManagementApplication.Contract.CustomerDiscount;
using ColleagueDiscountManagementApplication.Contract.DiscountCode;
using DiscountManagement.Application;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Domain.DiscountCode;
using DiscountManagement.Domain.UserDiscountAgg;
using DiscountManagement.Infrastructure.Permissions;
using DiscountManagementInfrastructure.EfCore;
using DiscountManagementInfrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Afg.Azad.UnQuery.Contract.Discount;
using Afg.Azad.UnQuery.Query;

namespace DiscountManagement.Infrastructure
{
    public class DiscountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICustomerDiscountApplication, CustomerApplication>();

            services.AddScoped<IColleagueRepository, ColleagueRepository>();
            services.AddScoped<IColleagueApplication, ColleagueApplication>();

            services.AddScoped<IDiscountCodeApplication, DiscountCodeApplication>();
            services.AddScoped<IDiscountCodeRepository, DiscountCodeRepository>();

            services.AddScoped<IDiscountQuery, DiscountQuery>();

            services.AddScoped<IUserDiscountRepository, UserDiscountRepository>();

            services.AddScoped<IPermissionExposer, DiscountPermissionExposer>();


            services.AddDbContext<DiscountContext>(option => { option.UseSqlServer(connectionString); });
        }
    }
}