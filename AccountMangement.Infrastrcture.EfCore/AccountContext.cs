using _0_FrameWork.Application;
using AccountManagement.Domain.Account.Agg;
using AccountManagement.Domain.ProvinceAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using _0_Framework.Application;

namespace AccountManagement.Infrastructure.EfCore
{
    public class AccountContext : DbContext
    {
        private readonly IPasswordHasher _passwordHasher;
        public AccountContext(DbContextOptions<AccountContext> options, IPasswordHasher passwordHasher) : base(options)
        {
            _passwordHasher = passwordHasher;
        }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.ApplyConfiguration(new AccountMapping(_passwordHasher));
            var assembly = typeof(AccountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}