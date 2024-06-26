using AccountManagement.Domain.Account.Agg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.EfCore.Mapping;

public class UserMapping : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> builder)
    {
        builder.ToTable("UserInfo");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.NationalCode).HasMaxLength(10).IsRequired();
        builder.Property(x => x.NationalPhoto).HasMaxLength(1000).IsRequired();
        builder.Property(x => x.FatherName).HasMaxLength(100);
        builder.Property(x => x.PersonalPhoto).HasMaxLength(1000);
        builder.HasOne(x => x.Account);
    }
}