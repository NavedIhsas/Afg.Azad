using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.ForumAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
   //public partial class QuestionMapping:IEntityTypeConfiguration<ForumQuestion>
   // {
   //     public void Configure(EntityTypeBuilder<ForumQuestion> builder)
   //     {
   //         builder.HasKey(x => x.Id);
   //         builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
   //         builder.Property(x => x.CourseId).IsRequired();
   //         builder.Property(x => x.Title).HasMaxLength(100);
   //         builder.Property(x => x.Slug).HasMaxLength(100);
   //         builder.HasMany(x => x.Answers).WithOne(x => x.ForumQuestion).HasForeignKey(x => x.QuestionId);
   //         builder.HasOne(x => x.Course).WithMany(x => x.Questions).HasForeignKey(x => x.CourseId);
   //     }
   // }
}
