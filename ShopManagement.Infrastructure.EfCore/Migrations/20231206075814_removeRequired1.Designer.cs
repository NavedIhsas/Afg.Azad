﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopManagement.Infrastructure.EfCore;

#nullable disable

namespace ShopManagement.Infrastructure.EfCore.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20231206075814_removeRequired1")]
    partial class removeRequired1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShopManagement.Domain.Contact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Fullname")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<string>("Message")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("Contacts", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.CourseAgg.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CanonicalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<long>("CourseGroupId")
                        .HasColumnType("bigint");

                    b.Property<long>("CourseLevelId")
                        .HasColumnType("bigint");

                    b.Property<long>("CourseStatusId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DemoVideoPoster")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("File")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("KeyWords")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<string>("MetaDescription")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Picture")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PictureAlt")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PictureTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<long>("TeacherId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CourseGroupId");

                    b.HasIndex("CourseLevelId");

                    b.HasIndex("CourseStatusId");

                    b.ToTable("Courses", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.CourseEpisodeAgg.CourseEpisode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FileName")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<bool>("IsFree")
                        .HasColumnType("bit");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("CourseEpisodes", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.CourseGroupAgg.CourseGroup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemove")
                        .HasColumnType("bit");

                    b.Property<string>("KeyWords")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<string>("MetaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureAlt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SubGroupId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("SubGroupId");

                    b.ToTable("CourseGroups", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.CourseLevelAgg.CourseLevel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("CourseLevels", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            LanguageId = 2L,
                            Title = "Introductory"
                        },
                        new
                        {
                            Id = 2L,
                            LanguageId = 2L,
                            Title = "Intermediate"
                        },
                        new
                        {
                            Id = 3L,
                            LanguageId = 2L,
                            Title = "Advanced"
                        });
                });

            modelBuilder.Entity("ShopManagement.Domain.CourseStatusAgg.CourseStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("CourseStatus", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            LanguageId = 2L,
                            Title = "In Progress"
                        },
                        new
                        {
                            Id = 2L,
                            LanguageId = 2L,
                            Title = "Formed"
                        },
                        new
                        {
                            Id = 3L,
                            LanguageId = 2L,
                            Title = "Completed"
                        });
                });

            modelBuilder.Entity("ShopManagement.Domain.ForumAgg.Answer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long>("QuestionId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Answers", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.LanguageAgg.Language", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Culture")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Languages", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Culture = "Prs"
                        },
                        new
                        {
                            Id = 2L,
                            Culture = "En"
                        },
                        new
                        {
                            Id = 3L,
                            Culture = "Ps"
                        });
                });

            modelBuilder.Entity("ShopManagement.Domain.OnlineCourse.OnlineCourse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<TimeSpan>("Time")
                        .HasColumnType("time");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("onlineCourses", "Tbl");
                });

            modelBuilder.Entity("ShopManagement.Domain.OrderAgg.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsFinally")
                        .HasColumnType("bit");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<double>("OrderSum")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Orders", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.OrderDetailAgg.OrderDetail", b =>
                {
                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("OrderId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("OrderDetails", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.Quiz.Question", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CorrectAnswer")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("CorrectAnswerPoints")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstOption")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("FourthOption")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<string>("QuestionName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<long>("QuizId")
                        .HasColumnType("bigint");

                    b.Property<string>("SecondOption")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("ThirdOption")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.Quiz.Quiz", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("KeyWord")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<string>("MetaDes")
                        .IsRequired()
                        .HasMaxLength(170)
                        .HasColumnType("nvarchar(170)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("OnDate")
                        .HasColumnType("datetime2");

                    b.Property<TimeSpan>("PeriodTime")
                        .HasColumnType("time");

                    b.Property<int>("QuizStatus")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Quizzes", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.Quiz.UserResult", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<int>("PointsEarned")
                        .HasColumnType("int");

                    b.Property<long>("QuizId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<int>("UsersCorrectAnswers")
                        .HasColumnType("int");

                    b.Property<int>("UsersWrongAnswers")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("UserResults", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.UserActivity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Activity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<string>("Method")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Path")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("UserActivities", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.UserCoursesAgg.UserCourse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LanguageId")
                        .HasColumnType("bigint");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("UserCourses", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.Visitors.Device", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Family")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSpider")
                        .HasColumnType("bit");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Devices", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.Visitors.OnlineVisitors", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("OnlineVisitors", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.Visitors.Visitor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("BrowserId")
                        .HasColumnType("bigint");

                    b.Property<string>("CurrentLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("DeviceId")
                        .HasColumnType("bigint");

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Method")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OperationSystemId")
                        .HasColumnType("bigint");

                    b.Property<string>("PhysicalPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Protocol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferrerLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("VisitorId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrowserId");

                    b.HasIndex("DeviceId");

                    b.HasIndex("OperationSystemId");

                    b.ToTable("Visitors", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.Visitors.VisitorVersion", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Family")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VisitorVersions", "dbo");
                });

            modelBuilder.Entity("ShopManagement.Domain.CourseAgg.Course", b =>
                {
                    b.HasOne("ShopManagement.Domain.CourseGroupAgg.CourseGroup", "CourseGroup")
                        .WithMany("Courses")
                        .HasForeignKey("CourseGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopManagement.Domain.CourseLevelAgg.CourseLevel", "CourseLevel")
                        .WithMany("Courses")
                        .HasForeignKey("CourseLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopManagement.Domain.CourseStatusAgg.CourseStatus", "CourseStatus")
                        .WithMany("Courses")
                        .HasForeignKey("CourseStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("ShopManagement.Domain.ToBeLearn.NeedToLearn", "NeedToLearns", b1 =>
                        {
                            b1.Property<long>("CourseId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Title")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("CourseId", "Id");

                            b1.ToTable("NeedToLearn", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("CourseId");
                        });

                    b.OwnsMany("ShopManagement.Domain.ToBeLearn.ToBeLearn", "ToBeLearns", b1 =>
                        {
                            b1.Property<long>("CourseId")
                                .HasColumnType("bigint");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"));

                            b1.Property<string>("Title")
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("CourseId", "Id");

                            b1.ToTable("ToBeLearn", "dbo");

                            b1.WithOwner()
                                .HasForeignKey("CourseId");
                        });

                    b.Navigation("CourseGroup");

                    b.Navigation("CourseLevel");

                    b.Navigation("CourseStatus");

                    b.Navigation("NeedToLearns");

                    b.Navigation("ToBeLearns");
                });

            modelBuilder.Entity("ShopManagement.Domain.CourseEpisodeAgg.CourseEpisode", b =>
                {
                    b.HasOne("ShopManagement.Domain.CourseAgg.Course", "Course")
                        .WithMany("CourseEpisodes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ShopManagement.Domain.CourseGroupAgg.CourseGroup", b =>
                {
                    b.HasOne("ShopManagement.Domain.CourseGroupAgg.CourseGroup", "SubGroup")
                        .WithMany("Groups")
                        .HasForeignKey("SubGroupId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("SubGroup");
                });

            modelBuilder.Entity("ShopManagement.Domain.OnlineCourse.OnlineCourse", b =>
                {
                    b.HasOne("ShopManagement.Domain.CourseAgg.Course", "Course")
                        .WithMany("OnlineCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ShopManagement.Domain.OrderDetailAgg.OrderDetail", b =>
                {
                    b.HasOne("ShopManagement.Domain.CourseAgg.Course", "Course")
                        .WithMany("OrderDetails")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShopManagement.Domain.OrderAgg.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ShopManagement.Domain.Quiz.Question", b =>
                {
                    b.HasOne("ShopManagement.Domain.Quiz.Quiz", "Quiz")
                        .WithMany("QuizQuestions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("ShopManagement.Domain.Quiz.Quiz", b =>
                {
                    b.HasOne("ShopManagement.Domain.CourseAgg.Course", "Course")
                        .WithMany("Quizzes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ShopManagement.Domain.Quiz.UserResult", b =>
                {
                    b.HasOne("ShopManagement.Domain.Quiz.Quiz", "Quiz")
                        .WithMany("UserResults")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("ShopManagement.Domain.UserCoursesAgg.UserCourse", b =>
                {
                    b.HasOne("ShopManagement.Domain.CourseAgg.Course", "Course")
                        .WithMany("UserCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ShopManagement.Domain.Visitors.Visitor", b =>
                {
                    b.HasOne("ShopManagement.Domain.Visitors.VisitorVersion", "Browser")
                        .WithMany()
                        .HasForeignKey("BrowserId");

                    b.HasOne("ShopManagement.Domain.Visitors.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId");

                    b.HasOne("ShopManagement.Domain.Visitors.VisitorVersion", "OperationSystem")
                        .WithMany()
                        .HasForeignKey("OperationSystemId");

                    b.Navigation("Browser");

                    b.Navigation("Device");

                    b.Navigation("OperationSystem");
                });

            modelBuilder.Entity("ShopManagement.Domain.CourseAgg.Course", b =>
                {
                    b.Navigation("CourseEpisodes");

                    b.Navigation("OnlineCourses");

                    b.Navigation("OrderDetails");

                    b.Navigation("Quizzes");

                    b.Navigation("UserCourses");
                });

            modelBuilder.Entity("ShopManagement.Domain.CourseGroupAgg.CourseGroup", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Groups");
                });

            modelBuilder.Entity("ShopManagement.Domain.CourseLevelAgg.CourseLevel", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("ShopManagement.Domain.CourseStatusAgg.CourseStatus", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("ShopManagement.Domain.OrderAgg.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("ShopManagement.Domain.Quiz.Quiz", b =>
                {
                    b.Navigation("QuizQuestions");

                    b.Navigation("UserResults");
                });
#pragma warning restore 612, 618
        }
    }
}
