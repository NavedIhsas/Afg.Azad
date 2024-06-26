using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.Quiz;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{
    internal class QuizMapping:IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.MetaDes).HasMaxLength(170).IsRequired();
            builder.Property(x => x.KeyWord).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(200).IsRequired();
            builder.HasOne(x => x.Course).WithMany(x => x.Quizzes).HasForeignKey(x => x.CourseId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.QuizQuestions).WithOne(x => x.Quiz).HasForeignKey(x => x.QuizId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
    
    public class QuestionQuizMapping : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CorrectAnswer).HasMaxLength(1000);
            builder.Property(x => x.FirstOption).HasMaxLength(1000);
            builder.Property(x => x.SecondOption).HasMaxLength(1000);
            builder.Property(x => x.ThirdOption).HasMaxLength(1000);
            builder.Property(x => x.FourthOption).HasMaxLength(1000);
            builder.Property(x => x.QuestionName).HasMaxLength(500).IsRequired();
        }
    }
}
