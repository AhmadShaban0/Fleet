﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using future_1_.Data;

namespace future_1_.Migrations
{
    [DbContext(typeof(FutureDbContext))]
    [Migration("20230321055845_newAnn")]
    partial class newAnn
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("future_1_.Models.Driver", b =>
                {
                    b.Property<int>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("DriverId");

                    b.ToTable("drivers");
                });

            modelBuilder.Entity("future_1_.Models.Fleet", b =>
                {
                    b.Property<int>("FleetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BoardNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FleetState")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("effectiveness")
                        .HasColumnType("int");

                    b.Property<int>("fleetModel")
                        .HasColumnType("int");

                    b.Property<string>("fleetType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FleetId");

                    b.HasIndex("RegionId");

                    b.ToTable("fleets");
                });

            modelBuilder.Entity("future_1_.Models.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegionId");

                    b.ToTable("regions");
                });

            modelBuilder.Entity("future_1_.Models.School", b =>
                {
                    b.Property<int>("SchoolId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("SchoolType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolId");

                    b.HasIndex("RegionId");

                    b.ToTable("schools");
                });

            modelBuilder.Entity("future_1_.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("students");
                });

            modelBuilder.Entity("future_1_.Models.TransportationEntity", b =>
                {
                    b.Property<int>("TransportationEntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ArabicName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<string>("website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransportationEntityId");

                    b.HasIndex("RegionId");

                    b.ToTable("transportationEntities");
                });

            modelBuilder.Entity("future_1_.Models.Fleet", b =>
                {
                    b.HasOne("future_1_.Models.Region", "region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("region");
                });

            modelBuilder.Entity("future_1_.Models.School", b =>
                {
                    b.HasOne("future_1_.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });

            modelBuilder.Entity("future_1_.Models.TransportationEntity", b =>
                {
                    b.HasOne("future_1_.Models.Region", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
