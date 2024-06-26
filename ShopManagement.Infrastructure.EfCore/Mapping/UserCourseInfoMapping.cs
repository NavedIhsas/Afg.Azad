using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.UserCoursesAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class UserCourseInfoMapping:IEntityTypeConfiguration<UserCourseInfo>
    {
        public void Configure(EntityTypeBuilder<UserCourseInfo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FatherName).HasMaxLength(128);
            builder.Property(x => x.Area).HasMaxLength(128);
            builder.Property(x => x.NationalCode).HasMaxLength(128);
            builder.Property(x => x.NationalPhoto).HasMaxLength(1000);
            builder.Property(x => x.PersonalPhoto).HasMaxLength(1000);
            builder.Property(x => x.Gender).HasMaxLength(20);
            builder.Property(x => x.Mobile).HasMaxLength(20);
        }
    }
}
