﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StocksApplication.Models;

#nullable disable

namespace StocksApplication.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StocksApplication.Models.Company", b =>
                {
                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Iexid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Symbol");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("StocksApplication.Models.CompanyDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CEO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exchange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sector")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CompanyDetails");
                });

            modelBuilder.Entity("StocksApplication.Models.CompanyDividend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DeclaredDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CompanyDividend");
                });

            modelBuilder.Entity("StocksApplication.Models.CompanyQuote", b =>
                {
                    b.Property<int>("QuoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuoteId"), 1L, 1);

                    b.Property<bool>("IsStockAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("close")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("companyname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("high")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("latestprice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("low")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("marketCap")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("open")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("previousClose")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("primaryexchange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sector")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuoteId");

                    b.ToTable("CompaniesQuote");
                });

            modelBuilder.Entity("StocksApplication.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeedbackMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Feedback");
                });
#pragma warning restore 612, 618
        }
    }
}
