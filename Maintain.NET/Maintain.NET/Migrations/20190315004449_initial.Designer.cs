﻿// <auto-generated />
using System;
using Maintain.NET.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Maintain.NET.Migrations
{
    [DbContext(typeof(MaintainDbContext))]
    [Migration("20190315004449_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Maintain.NET.Models.MaintenanceTask", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("MaximumInterval");

                    b.Property<long>("MinimumInterval");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<long>("RecommendedInterval");

                    b.HasKey("ID");

                    b.ToTable("MaintenanceTasks");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            MaximumInterval = 15000L,
                            MinimumInterval = 2L,
                            Name = "Clean Fish Tank",
                            RecommendedInterval = 1000L
                        },
                        new
                        {
                            ID = 2,
                            MaximumInterval = 100000L,
                            MinimumInterval = 2L,
                            Name = "Oil Change",
                            RecommendedInterval = 1000L
                        },
                        new
                        {
                            ID = 3,
                            MaximumInterval = 10000L,
                            MinimumInterval = 2L,
                            Name = "Water Crop",
                            RecommendedInterval = 1000L
                        },
                        new
                        {
                            ID = 4,
                            MaximumInterval = 10000L,
                            MinimumInterval = 2L,
                            Name = "Harvest Crop",
                            RecommendedInterval = 1000L
                        });
                });

            modelBuilder.Entity("Maintain.NET.Models.UserMaintenanceHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Interval");

                    b.Property<int>("MaintenanceRef");

                    b.Property<DateTime>("TimeComplete");

                    b.Property<string>("UserID");

                    b.Property<int>("UserMaintenanceTaskID");

                    b.Property<int?>("UserMaintenanceTaskMaintenanceTaskID");

                    b.Property<string>("UserMaintenanceTaskUserID");

                    b.HasKey("ID");

                    b.HasIndex("UserMaintenanceTaskMaintenanceTaskID", "UserMaintenanceTaskUserID");

                    b.ToTable("UserMaintenanceHistories");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Interval = 1000L,
                            MaintenanceRef = 1,
                            TimeComplete = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserID = "ghost@ghost.com",
                            UserMaintenanceTaskID = 1
                        },
                        new
                        {
                            ID = 2,
                            Interval = 1000L,
                            MaintenanceRef = 2,
                            TimeComplete = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserID = "ghost@ghost.com",
                            UserMaintenanceTaskID = 2
                        },
                        new
                        {
                            ID = 3,
                            Interval = 1000L,
                            MaintenanceRef = 3,
                            TimeComplete = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserID = "ghost@ghost.com",
                            UserMaintenanceTaskID = 3
                        },
                        new
                        {
                            ID = 4,
                            Interval = 1000L,
                            MaintenanceRef = 4,
                            TimeComplete = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserID = "ghost@ghost.com",
                            UserMaintenanceTaskID = 4
                        });
                });

            modelBuilder.Entity("Maintain.NET.Models.UserMaintenanceTask", b =>
                {
                    b.Property<int>("MaintenanceTaskID");

                    b.Property<string>("UserID");

                    b.Property<int>("ID");

                    b.Property<long>("LastComplete");

                    b.Property<long>("NextComplete");

                    b.HasKey("MaintenanceTaskID", "UserID");

                    b.ToTable("UserMaintenanceTasks");

                    b.HasData(
                        new
                        {
                            MaintenanceTaskID = 1,
                            UserID = "ghost@ghost.com",
                            ID = 1,
                            LastComplete = 0L,
                            NextComplete = 0L
                        },
                        new
                        {
                            MaintenanceTaskID = 2,
                            UserID = "ghost@ghost.com",
                            ID = 2,
                            LastComplete = 0L,
                            NextComplete = 0L
                        },
                        new
                        {
                            MaintenanceTaskID = 3,
                            UserID = "ghost@ghost.com",
                            ID = 3,
                            LastComplete = 0L,
                            NextComplete = 0L
                        },
                        new
                        {
                            MaintenanceTaskID = 4,
                            UserID = "ghost@ghost.com",
                            ID = 4,
                            LastComplete = 0L,
                            NextComplete = 0L
                        });
                });

            modelBuilder.Entity("Maintain.NET.Models.UserMaintenanceHistory", b =>
                {
                    b.HasOne("Maintain.NET.Models.UserMaintenanceTask", "UserMaintenanceTask")
                        .WithMany("UserMaintenanceHistory")
                        .HasForeignKey("UserMaintenanceTaskMaintenanceTaskID", "UserMaintenanceTaskUserID");
                });

            modelBuilder.Entity("Maintain.NET.Models.UserMaintenanceTask", b =>
                {
                    b.HasOne("Maintain.NET.Models.MaintenanceTask", "MaintenanceTask")
                        .WithMany("UserMaintenanceTasks")
                        .HasForeignKey("MaintenanceTaskID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}