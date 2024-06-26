﻿// <auto-generated />
using System;
using AccountManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AccountManagement.Infrastructure.EfCore.Migrations
{
    [DbContext(typeof(AccountContext))]
    partial class AccountContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AccountManagement.Domain.Account.Agg.Account", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AboutMe")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ActiveCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avatar")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("CityId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("EmailConfirm")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Gander")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AboutMe = "",
                            ActiveCode = "",
                            Area = "",
                            Avatar = "",
                            BirthDate = new DateTime(1997, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreationDate = new DateTime(2023, 12, 2, 11, 58, 47, 143, DateTimeKind.Local).AddTicks(165),
                            Email = "qodratullahahsas@gmail.com",
                            EmailConfirm = true,
                            FirstName = "نوید",
                            Gander = "مرد",
                            IsActive = true,
                            IsDelete = false,
                            LastName = "احساس",
                            Password = "10000.LrTzJb8TzEOEJmD6AlmZeQ==.QAl12DN9QMFNfpXnmCxRki7BTpXvzuga4GLb95ciK9w=",
                            Phone = "077***",
                            RoleId = 6L
                        });
                });

            modelBuilder.Entity("AccountManagement.Domain.Account.Agg.Teacher", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<string>("Bio")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Resumes")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Skills")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("UserTeachers", "dbo");
                });

            modelBuilder.Entity("AccountManagement.Domain.Account.Agg.UserInfo", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FatherName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<string>("NationalCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("NationalPhoto")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("PersonalPhoto")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("UserInfo", "dbo");
                });

            modelBuilder.Entity("AccountManagement.Domain.ProvinceAgg.City", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<long?>("ProvinceId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities", "dbo");
                });

            modelBuilder.Entity("AccountManagement.Domain.ProvinceAgg.Province", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Provinces", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 2L,
                            Name = "Kabul"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Herat"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Balkh"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Ghazni"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Bamyan"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Badghis"
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Daykundi"
                        },
                        new
                        {
                            Id = 9L,
                            Name = "Urozgan"
                        },
                        new
                        {
                            Id = 10L,
                            Name = "Farah"
                        },
                        new
                        {
                            Id = 11L,
                            Name = "Faryab"
                        },
                        new
                        {
                            Id = 12L,
                            Name = "Paktia"
                        },
                        new
                        {
                            Id = 13L,
                            Name = "Paktika"
                        },
                        new
                        {
                            Id = 14L,
                            Name = "Samangan"
                        },
                        new
                        {
                            Id = 15L,
                            Name = "Nuristan"
                        },
                        new
                        {
                            Id = 16L,
                            Name = "Badakhshan"
                        },
                        new
                        {
                            Id = 17L,
                            Name = "Nimroz"
                        },
                        new
                        {
                            Id = 19L,
                            Name = "Ghor"
                        },
                        new
                        {
                            Id = 20L,
                            Name = "Helmand"
                        },
                        new
                        {
                            Id = 21L,
                            Name = "Logar"
                        },
                        new
                        {
                            Id = 22L,
                            Name = "Parwan"
                        },
                        new
                        {
                            Id = 23L,
                            Name = "Maidan Wardak"
                        },
                        new
                        {
                            Id = 24L,
                            Name = "Baghlan"
                        },
                        new
                        {
                            Id = 25L,
                            Name = "Panjshir"
                        },
                        new
                        {
                            Id = 26L,
                            Name = "Khost"
                        },
                        new
                        {
                            Id = 27L,
                            Name = "Zabul"
                        },
                        new
                        {
                            Id = 28L,
                            Name = "Sar-e Pol"
                        },
                        new
                        {
                            Id = 29L,
                            Name = "Kapisa"
                        },
                        new
                        {
                            Id = 30L,
                            Name = "Laghman"
                        },
                        new
                        {
                            Id = 32L,
                            Name = "Nangarhar"
                        },
                        new
                        {
                            Id = 33L,
                            Name = "Konar"
                        },
                        new
                        {
                            Id = 34L,
                            Name = "Kunduz"
                        },
                        new
                        {
                            Id = 35L,
                            Name = "Kandahar"
                        });
                });

            modelBuilder.Entity("AccountManagement.Domain.RoleAgg.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Roles", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreationDate = new DateTime(2023, 12, 2, 11, 58, 47, 144, DateTimeKind.Local).AddTicks(9319),
                            Name = "مدیر سایت"
                        },
                        new
                        {
                            Id = 2L,
                            CreationDate = new DateTime(2023, 12, 2, 11, 58, 47, 144, DateTimeKind.Local).AddTicks(9348),
                            Name = "استاد"
                        },
                        new
                        {
                            Id = 3L,
                            CreationDate = new DateTime(2023, 12, 2, 11, 58, 47, 144, DateTimeKind.Local).AddTicks(9354),
                            Name = "ادمین"
                        },
                        new
                        {
                            Id = 4L,
                            CreationDate = new DateTime(2023, 12, 2, 11, 58, 47, 144, DateTimeKind.Local).AddTicks(9357),
                            Name = "کاربر عادی"
                        },
                        new
                        {
                            Id = 5L,
                            CreationDate = new DateTime(2023, 12, 2, 11, 58, 47, 144, DateTimeKind.Local).AddTicks(9361),
                            Name = "بلاگر"
                        },
                        new
                        {
                            Id = 6L,
                            CreationDate = new DateTime(2023, 12, 2, 11, 58, 47, 144, DateTimeKind.Local).AddTicks(9368),
                            Name = "بدون احراز"
                        });
                });

            modelBuilder.Entity("AccountManagement.Domain.Account.Agg.Account", b =>
                {
                    b.HasOne("AccountManagement.Domain.ProvinceAgg.City", "City")
                        .WithMany("Accounts")
                        .HasForeignKey("CityId");

                    b.HasOne("AccountManagement.Domain.RoleAgg.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("AccountManagement.Domain.Account.Agg.Teacher", b =>
                {
                    b.HasOne("AccountManagement.Domain.Account.Agg.Account", "Account")
                        .WithMany("Teachers")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("AccountManagement.Domain.Account.Agg.UserInfo", b =>
                {
                    b.HasOne("AccountManagement.Domain.Account.Agg.Account", "Account")
                        .WithOne("UserInfo")
                        .HasForeignKey("AccountManagement.Domain.Account.Agg.UserInfo", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("AccountManagement.Domain.ProvinceAgg.City", b =>
                {
                    b.HasOne("AccountManagement.Domain.ProvinceAgg.Province", "Province")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("AccountManagement.Domain.RoleAgg.Role", b =>
                {
                    b.OwnsMany("AccountManagement.Domain.RoleAgg.Permission", "Permissions", b1 =>
                        {
                            b1.Property<long>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("bigint");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<long>("Id"));

                            b1.Property<int>("Code")
                                .HasColumnType("int");

                            b1.Property<long>("RoleId")
                                .HasColumnType("bigint");

                            b1.HasKey("Id");

                            b1.HasIndex("RoleId");

                            b1.ToTable("RolePermissions", "dbo");

                            b1.WithOwner("Role")
                                .HasForeignKey("RoleId");

                            b1.Navigation("Role");
                        });

                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("AccountManagement.Domain.Account.Agg.Account", b =>
                {
                    b.Navigation("Teachers");

                    b.Navigation("UserInfo");
                });

            modelBuilder.Entity("AccountManagement.Domain.ProvinceAgg.City", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("AccountManagement.Domain.ProvinceAgg.Province", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("AccountManagement.Domain.RoleAgg.Role", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
