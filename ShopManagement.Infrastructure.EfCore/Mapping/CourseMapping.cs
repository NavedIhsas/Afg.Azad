using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CourseAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class CourseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.ShortDescription).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Code).HasMaxLength(20);
            builder.Property(x => x.File).HasMaxLength(500);
            builder.Property(x => x.Picture).HasMaxLength(500);
            builder.Property(x => x.PictureAlt).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(100).IsRequired();
            builder.Property(x => x.KeyWords).HasMaxLength(100);
            builder.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(200).IsRequired();
            //builder.Property(x => x.CanonicalAddress).HasMaxLength(500).IsRequired();
            builder.HasOne(x => x.CourseStatus).WithMany(x => x.Courses).HasForeignKey(x => x.CourseStatusId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.CourseLevel).WithMany(x => x.Courses).HasForeignKey(x => x.CourseLevelId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.CourseGroup).WithMany(x => x.Courses).HasForeignKey(x => x.CourseGroupId).OnDelete(DeleteBehavior.Cascade);

            builder.OwnsMany(x => x.ToBeLearns, navigationBuilder =>
            {
                navigationBuilder.Property(x => x.Title).HasMaxLength(100);
            });

            builder.OwnsMany(x => x.NeedToLearns, navigationBuilder =>
           {
               navigationBuilder.Property(x => x.Title).HasMaxLength(100);
           });

        }
    }
}