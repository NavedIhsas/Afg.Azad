using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CourseLevelAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class CourseLevelMapping : IEntityTypeConfiguration<CourseLevel>
    {
        public void Configure(EntityTypeBuilder<CourseLevel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();

            builder.HasData(new CourseLevel { Title = "Introductory", Id = 1, LanguageId = 2 });
            builder.HasData(new CourseLevel { Title = "Intermediate", Id = 2, LanguageId = 2 });
            builder.HasData(new CourseLevel { Title = "Advanced", Id = 3, LanguageId = 2 });
        }
    }
}