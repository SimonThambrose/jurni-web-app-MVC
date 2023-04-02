﻿// <auto-generated />
using System;
using JurniWebApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JurniWebApp.Migrations
{
    [DbContext(typeof(JurniWebAppDbContext))]
    [Migration("20230402115208_update_user_password_migration")]
    partial class update_user_password_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("JurniWebApp.Data.Entities.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Likes")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("varchar(90)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("JurniWebApp.Data.Entities.ContactRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("varchar(90)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<bool>("IsEnterprisePlan")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(8)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("ContactRequests");
                });

            modelBuilder.Entity("JurniWebApp.Data.Entities.Plan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Plans");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Limited to 10 matches per day.",
                            Name = "Free",
                            Price = 0
                        },
                        new
                        {
                            Id = 2,
                            Description = "Limited to 50 matches per day, with additional features.",
                            Name = "Basic",
                            Price = 10
                        },
                        new
                        {
                            Id = 3,
                            Description = "Unlimited matches per day, with additional features and support.",
                            Name = "Premium",
                            Price = 20
                        },
                        new
                        {
                            Id = 4,
                            Description = "Unlimited matches per day, with additional features and support. Response within 72 hours.",
                            Name = "Enterprise"
                        });
                });

            modelBuilder.Entity("JurniWebApp.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("varchar(90)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<int?>("PlanId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 4, 2, 13, 52, 8, 773, DateTimeKind.Local).AddTicks(47),
                            Email = "johnj@jurni.nl",
                            FirstName = "John",
                            IsAdmin = true,
                            LastName = "Johnson",
                            PasswordHash = new byte[] { 201, 184, 127, 71, 192, 49, 79, 239, 1, 124, 164, 227, 92, 2, 235, 140, 207, 203, 106, 116, 212, 229, 110, 215, 114, 239, 209, 151, 51, 2, 211, 250, 88, 25, 67, 83, 116, 49, 241, 207, 189, 75, 253, 171, 98, 111, 29, 71, 139, 25, 86, 39, 72, 17, 225, 110, 28, 7, 236, 46, 45, 110, 161, 66 },
                            PasswordSalt = new byte[] { 243, 103, 39, 63, 188, 72, 155, 235, 201, 226, 63, 215, 113, 96, 251, 86, 116, 229, 129, 211, 112, 239, 172, 145, 201, 204, 172, 213, 2, 28, 94, 78, 47, 102, 232, 231, 156, 13, 78, 208, 150, 63, 62, 211, 107, 29, 16, 101, 207, 32, 93, 112, 181, 122, 42, 85, 129, 79, 220, 249, 37, 245, 130, 242, 24, 83, 238, 178, 190, 100, 21, 92, 141, 220, 92, 110, 213, 123, 140, 82, 76, 22, 188, 10, 41, 146, 22, 249, 154, 59, 29, 173, 48, 249, 102, 214, 255, 107, 149, 67, 232, 56, 113, 30, 201, 143, 244, 56, 120, 215, 185, 51, 139, 120, 88, 33, 209, 190, 20, 20, 109, 143, 156, 158, 166, 143, 14, 248 },
                            UpdatedAt = new DateTime(2023, 4, 2, 13, 52, 8, 773, DateTimeKind.Local).AddTicks(85)
                        });
                });

            modelBuilder.Entity("JurniWebApp.Data.Entities.Blog", b =>
                {
                    b.HasOne("JurniWebApp.Data.Entities.User", "Author")
                        .WithMany("Blogs")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("JurniWebApp.Data.Entities.User", b =>
                {
                    b.HasOne("JurniWebApp.Data.Entities.Plan", "Plan")
                        .WithMany("Users")
                        .HasForeignKey("PlanId");

                    b.Navigation("Plan");
                });

            modelBuilder.Entity("JurniWebApp.Data.Entities.Plan", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("JurniWebApp.Data.Entities.User", b =>
                {
                    b.Navigation("Blogs");
                });
#pragma warning restore 612, 618
        }
    }
}
