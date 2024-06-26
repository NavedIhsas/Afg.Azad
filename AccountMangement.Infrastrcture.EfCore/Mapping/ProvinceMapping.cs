using AccountManagement.Domain.ProvinceAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EfCore.Mapping
{
   public class ProvinceMapping:IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.HasMany(x => x.Cities).WithOne(x => x.Province).HasForeignKey(x => x.ProvinceId);
            builder.HasData(new Province("Kabul", 2));
            builder.HasData(new Province("Herat", 3));
            builder.HasData(new Province("Balkh", 4));
            builder.HasData(new Province("Ghazni", 5));
            builder.HasData(new Province("Bamyan", 6));
            builder.HasData(new Province("Badghis", 7));
            builder.HasData(new Province("Daykundi", 8));
            builder.HasData(new Province("Urozgan", 9));
            builder.HasData(new Province("Farah", 10));
            builder.HasData(new Province("Faryab", 11));
            builder.HasData(new Province("Paktia", 12));
            builder.HasData(new Province("Paktika", 13));
            builder.HasData(new Province("Samangan", 14));
            builder.HasData(new Province("Nuristan", 15));
            builder.HasData(new Province("Badakhshan", 16));
            builder.HasData(new Province("Nimroz", 17));
            builder.HasData(new Province("Ghor", 19));
            builder.HasData(new Province("Helmand", 20));
            builder.HasData(new Province("Logar", 21));
            builder.HasData(new Province("Parwan", 22));
            builder.HasData(new Province("Maidan Wardak", 23));
            builder.HasData(new Province("Baghlan", 24));
            builder.HasData(new Province("Panjshir", 25));
            builder.HasData(new Province("Khost", 26));
            builder.HasData(new Province("Zabul", 27));
            builder.HasData(new Province("Sar-e Pol", 28));
            builder.HasData(new Province("Kapisa", 29));
            builder.HasData(new Province("Laghman", 30));
            builder.HasData(new Province("Nangarhar", 32));
            builder.HasData(new Province("Konar", 33));
            builder.HasData(new Province("Kunduz", 34));
            builder.HasData(new Province("Kandahar", 35));
        }
    }
}
