using Maintain.NET.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Models
{
    public class DatabaseContext : MaintainDbContext
    {
        public DatabaseContext(MaintainDbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<MaintenanceTask> MaintenanceTask { get; set; }

    }
}
