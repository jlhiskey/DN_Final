using Maintain.NET.Models;
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
            //TODO: Add Seeds here
            modelBuilder.Entity<MaintenanceTask>().HasData(
                new MaintenanceTask("Fish Tank")
                {
                    ID = 1,
                    RecommendedInterval = 2
                },
                new MaintenanceTask("Oil Change")
                {
                    ID = 2,
                    RecommendedInterval = 4
                }
                );

        }

        //TODO: Add table references here.
        public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }
        public DbSet<UserMaintenanceTask> UserMaintenanceTasks { get; set; }
        public DbSet<UserMaintenanceHistory> UserMaintenanceHistories { get; set; }
        
    }
}

