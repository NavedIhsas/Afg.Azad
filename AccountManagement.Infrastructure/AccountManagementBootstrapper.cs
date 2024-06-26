using _0_FrameWork.Domain.Infrastructure;
using AccountManagement.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.City;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Domain.ProvinceAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Infrastructure.EfCore;
using AccountManagement.Infrastructure.EfCore.Repository;
using AccountManagement.Infrastructure.Permissions;
using AccountManagement.Infrastructure.ShopAcl.Lang;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Afg.Azad.UnQuery.Contract.Account;
using Afg.Azad.UnQuery.Query;

namespace AccountManagement.Infrastructure
{
    public class AccountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountApplication, AccountApplication>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            services.AddScoped<IRoleApplication, RoleApplication>();
            services.AddScoped<IRoleRepository, RoleRepository>();

            services.AddScoped<IPermissionExposer, AccountPermissionExposer>();
            services.AddScoped<IAccountQuery, AccountQuery>();

             services.AddScoped<ICityApplication, CityApplication>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ILanguage, Language>();

            services.AddDbContext<AccountContext>(option => { option.UseSqlServer(connectionString); });
        }
    }
}