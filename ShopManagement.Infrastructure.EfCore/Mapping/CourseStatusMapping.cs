using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.CourseStatusAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    public class CourseStatusMapping : IEntityTypeConfiguration<CourseStatus>
    {
        public void Configure(EntityTypeBuilder<CourseStatus> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired();
            builder.HasData(new CourseStatus { Title = "In Progress", Id = 1, LanguageId = 2 });
            builder.HasData(new CourseStatus { Title = "Formed", Id = 2, LanguageId = 2 });
            builder.HasData(new CourseStatus { Title = "Completed", Id = 3, LanguageId = 2 });
        }
    }
}