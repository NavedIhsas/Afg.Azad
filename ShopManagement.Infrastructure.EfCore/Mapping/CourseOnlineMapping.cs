using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.OnlineCourse;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class OnlineCourseMapping:IEntityTypeConfiguration<OnlineCourse>
    {
        public void Configure(EntityTypeBuilder<OnlineCourse> builder)
        {
            builder.ToTable("onlineCourses", "Tbl").HasKey(x => x.Id);
            builder.Property(x => x.Url).IsRequired().HasMaxLength(500);
            builder.Property(x=>x.Title).IsRequired().HasMaxLength(100);
            builder.HasOne(x=>x.Course).WithMany(x=>x.OnlineCourses).HasForeignKey(x=>x.CourseId).OnDelete(DeleteBehavior.Cascade); ;
        }
    }
}
