﻿using Maintain.NET.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Data
{
    public class MaintainDbContext : DbContext
    {
        public MaintainDbContext(DbContextOptions<MaintainDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite Key Associations
            modelBuilder.Entity<UserMaintenanceTask>().HasKey(umt => new { umt.MaintenanceTaskID, umt.UserID });

            // Composite Key Associations
            modelBuilder.Entity<UserMaintenanceHistory>().HasKey(umh => new { umh.UserID, umh.UserMaintenanceTaskID });

            //TODO: Add Seeds here
            modelBuilder.Entity<MaintenanceTask>().HasData(
                new MaintenanceTask("Fish Tank")
                {
                    ID = 1,
                    RecommendedInterval = 86400,
                    MaximumInterval = 172800,
                    MinimumInterval = 43200
                },
                new MaintenanceTask("Oil Change")
                {
                    ID = 2,
                    RecommendedInterval = 86400,
                    MaximumInterval = 172800,
                    MinimumInterval = 43200
                }
                );

            modelBuilder.Entity<UserMaintenanceTask>().HasData(
                new UserMaintenanceTask("ghost@ghost.com", 1)
                {
                    ID = 1,                    
                },
                new UserMaintenanceTask("ghost@ghost.com", 2)
                {
                    ID = 2,                    
                }
                );

            modelBuilder.Entity<UserMaintenanceHistory>().HasData(
                new UserMaintenanceHistory()
                {
                    ID = 1,
                    Interval = 86400,    
                    UserID = "ghost@ghost.com",
                    UserMaintenanceTaskID = 1
                },
                new UserMaintenanceHistory()
                {
                    ID = 2,
                    Interval = 86400,
                    UserID = "ghost@ghost.com",
                    UserMaintenanceTaskID = 2
                }
                );

        }

        //TODO: Add table references here.
        public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }
        public DbSet<UserMaintenanceTask> UserMaintenanceTasks { get; set; }
        public DbSet<UserMaintenanceHistory> UserMaintenanceHistories { get; set; }
        
    }
}

