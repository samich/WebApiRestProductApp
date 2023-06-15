﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApiRestProductApp.Data;

#nullable disable

namespace WebApiRestProductApp.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20230615023347_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.4.23259.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApiRestProductApp.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6f05804f-69f1-40df-a0bf-fa6e1384cc95"),
                            Category = "Phone",
                            Name = "iPhone 14 Pro max",
                            Price = 1299.99,
                            ReleaseDate = new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = new Guid("9bbb269d-1693-4db2-8229-ce1032ec8e65"),
                            Category = "Phone",
                            Name = "Samsung S23 Ultra",
                            Price = 999.99000000000001,
                            ReleaseDate = new DateTime(2023, 6, 14, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}