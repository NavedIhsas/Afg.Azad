using System;
using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Domain.Account.Agg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EfCore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        private readonly IPasswordHasher _passwordHasher;

        public AccountMapping(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }


        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Users");

            builder.HasData(new Account(1, "نوید", "احساس", "qodratullahahsas@gmail.com", "077***", _passwordHasher.Hash("aouUser"), "", true, true, false, "مرد", new DateTime(1997, 05, 28), null, RoleType.NoAuthorize, "", "", ""));

            builder.HasQueryFilter(x => x.IsActive);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(250).IsUnicode().IsRequired();
            builder.Property(x => x.Avatar).HasMaxLength(500);
            builder.Property(x => x.Password).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(20);
            builder.Property(x => x.Gander).HasMaxLength(10);
            builder.Property(x => x.AboutMe).HasMaxLength(1000);

            builder.HasOne(x => x.Role).WithMany(x => x.Accounts).HasForeignKey(x => x.RoleId).OnDelete(DeleteBehavior.Cascade); ;
            builder.HasMany(x => x.Teachers).WithOne(x => x.Account).HasForeignKey(x => x.AccountId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}