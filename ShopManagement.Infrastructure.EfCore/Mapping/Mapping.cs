using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.LanguageAgg;

namespace ShopManagement.Infrastructure.EfCore.Mapping
{


    public class LanguageMapping : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Culture).HasMaxLength(20);
            builder.HasData(new Language(1, "Prs"));
            builder.HasData(new Language(2, "En"));
            builder.HasData(new Language(3, "Ps"));
        }
    }
}
