﻿// <auto-generated />
using System;
using AspBlog.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AspBlog.Infrastructure.Migrations
{
    [DbContext(typeof(BlogDbContex))]
    [Migration("20240825230429_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AspBlog.Domain.Entities.PostInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ChangedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("changed_at");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<int>("CreatedById")
                        .HasColumnType("int")
                        .HasColumnName("created_by_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("description");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("post", "blog");

                    b.HasDiscriminator().HasValue("PostInfo");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("AspBlog.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("ChangedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("changed_at");

                    b.Property<int?>("ChangedById")
                        .HasColumnType("int")
                        .HasColumnName("changed_by_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("created_at");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("full_name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("password_hash");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("role");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.HasIndex("ChangedById");

                    b.ToTable("user", "blog");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            CreatedAt = new DateTime(2024, 8, 26, 1, 4, 28, 814, DateTimeKind.Local).AddTicks(2063),
                            FullName = "Admin",
                            PasswordHash = "AQAAAAIAAYagAAAAEDjMnrp33rrvr9tkGu7X7RTRFaOqSbiFTsbTThsE7CvEAp1Q0plN8H7P5Sr7mwD04Q==",
                            Role = "admin",
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("AspBlog.Domain.Entities.Post", b =>
                {
                    b.HasBaseType("AspBlog.Domain.Entities.PostInfo");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("content");

                    b.ToTable("post", "blog");

                    b.HasDiscriminator().HasValue("Post");
                });

            modelBuilder.Entity("AspBlog.Domain.Entities.PostInfo", b =>
                {
                    b.HasOne("AspBlog.Domain.Entities.User", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("AspBlog.Domain.Entities.User", b =>
                {
                    b.HasOne("AspBlog.Domain.Entities.User", "ChangedBy")
                        .WithMany()
                        .HasForeignKey("ChangedById");

                    b.Navigation("ChangedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
