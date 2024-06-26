using _0_FrameWork.Application;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EfCore.Mapping
{
    public class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.HasData(new Role("مدیر سایت", RoleType.Manager));
            builder.HasData(new Role("استاد", RoleType.Teacher));
            builder.HasData(new Role("ادمین",RoleType.Admin));
            builder.HasData(new Role("کاربر عادی",RoleType.User));
            builder.HasData(new Role("بلاگر",RoleType.Blogger));
            builder.HasData(new Role("بدون احراز",RoleType.NoAuthorize));
            builder.OwnsMany(x => x.Permissions, navigationBuilder =>
            {
                navigationBuilder.HasKey(x => x.Id);
                navigationBuilder.ToTable("RolePermissions");
                navigationBuilder.Property(x => x.Name).HasMaxLength(500);
                navigationBuilder.Ignore(x => x.Name);
                navigationBuilder.WithOwner(x => x.Role);
            });
        }
    }
}