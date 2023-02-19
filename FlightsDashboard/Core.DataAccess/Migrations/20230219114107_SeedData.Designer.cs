﻿// <auto-generated />
using System;
using Core.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230219114107_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.DataAccess.Models.AirLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("Core.DataAccess.Models.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrimaryCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("Core.DataAccess.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ISOCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Core.DataAccess.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AirLineId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FromId")
                        .HasColumnType("int");

                    b.Property<int?>("ToId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AirLineId");

                    b.HasIndex("FromId");

                    b.HasIndex("ToId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Core.DataAccess.Models.AirLine", b =>
                {
                    b.HasOne("Core.DataAccess.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Core.DataAccess.Models.Airport", b =>
                {
                    b.HasOne("Core.DataAccess.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Core.DataAccess.Models.Flight", b =>
                {
                    b.HasOne("Core.DataAccess.Models.AirLine", "AirLine")
                        .WithMany("Flights")
                        .HasForeignKey("AirLineId");

                    b.HasOne("Core.DataAccess.Models.Airport", "From")
                        .WithMany()
                        .HasForeignKey("FromId");

                    b.HasOne("Core.DataAccess.Models.Airport", "To")
                        .WithMany()
                        .HasForeignKey("ToId");

                    b.Navigation("AirLine");

                    b.Navigation("From");

                    b.Navigation("To");
                });

            modelBuilder.Entity("Core.DataAccess.Models.AirLine", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
