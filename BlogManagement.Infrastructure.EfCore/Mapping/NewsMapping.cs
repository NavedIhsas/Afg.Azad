using BlogManagement.Domain.NewsAgg;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastructure.EfCore.Mapping
{
    public class NewsMapping : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(500);
            builder.Property(x => x.ShortDescription).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(500);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.Slug).HasMaxLength(600);
            builder.Property(x => x.Keywords).HasMaxLength(100);
            builder.Property(x => x.MetaDescription).HasMaxLength(200);
            builder.Property(x => x.CanonicalAddress).HasMaxLength(1000);
            builder.OwnsMany(x => x.NewsPictures, opt =>
            {
                opt.Property(x => x.Picture).IsRequired().HasMaxLength(500);
            });
        }
    }
}
