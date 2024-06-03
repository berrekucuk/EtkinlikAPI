﻿// <auto-generated />
using System;
using EtkinlikAPI.Models.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EtkinlikAPI.Migrations
{
    [DbContext(typeof(EventContext))]
    [Migration("20240603184725_CategoryTableIconNull")]
    partial class CategoryTableIconNull
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EtkinlikAPI.Models.ORM.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("EtkinlikAPI.Models.ORM.ActivityImages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActivityID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ActivityID");

                    b.ToTable("ActivityImages");
                });

            modelBuilder.Entity("EtkinlikAPI.Models.ORM.AdminUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AdminUsers");
                });

            modelBuilder.Entity("EtkinlikAPI.Models.ORM.BlogPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("BlogPosts");
                });

            modelBuilder.Entity("EtkinlikAPI.Models.ORM.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("AddDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("35d3abe7-4fab-441f-87b4-b8933098f008"),
                            AddDate = new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6252),
                            IsDeleted = false,
                            Name = "Yazılım"
                        },
                        new
                        {
                            Id = new Guid("6f8861e8-eb28-4d64-acb9-b0935f90bc23"),
                            AddDate = new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6296),
                            IsDeleted = false,
                            Name = "Teknoloji"
                        },
                        new
                        {
                            Id = new Guid("86b38118-cdb9-4fed-a2e1-470a14020a15"),
                            AddDate = new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6315),
                            IsDeleted = false,
                            Name = "Eğitim"
                        },
                        new
                        {
                            Id = new Guid("07850c19-3582-45fe-88c4-08c6fc427b25"),
                            AddDate = new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6344),
                            IsDeleted = false,
                            Name = "Sağlık"
                        },
                        new
                        {
                            Id = new Guid("62ff6ba6-8dc3-489e-b36a-6efd9e6af739"),
                            AddDate = new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6362),
                            IsDeleted = false,
                            Name = "Spor"
                        },
                        new
                        {
                            Id = new Guid("626e4518-d7bd-4968-8a31-817cd07708ee"),
                            AddDate = new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6384),
                            IsDeleted = false,
                            Name = "Sanat"
                        },
                        new
                        {
                            Id = new Guid("381fc20a-7935-4777-ba2e-ecbe26d70c62"),
                            AddDate = new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6402),
                            IsDeleted = false,
                            Name = "Müzik"
                        },
                        new
                        {
                            Id = new Guid("5423c642-8f66-46fa-bc50-56cc53617788"),
                            AddDate = new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6419),
                            IsDeleted = false,
                            Name = "Eğlence"
                        },
                        new
                        {
                            Id = new Guid("a8355910-f137-4e70-8766-042a22f3fa52"),
                            AddDate = new DateTime(2024, 6, 3, 21, 47, 25, 520, DateTimeKind.Local).AddTicks(6436),
                            IsDeleted = false,
                            Name = "Diğer"
                        });
                });

            modelBuilder.Entity("EtkinlikAPI.Models.ORM.Activity", b =>
                {
                    b.HasOne("EtkinlikAPI.Models.ORM.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("EtkinlikAPI.Models.ORM.ActivityImages", b =>
                {
                    b.HasOne("EtkinlikAPI.Models.ORM.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");
                });
#pragma warning restore 612, 618
        }
    }
}
