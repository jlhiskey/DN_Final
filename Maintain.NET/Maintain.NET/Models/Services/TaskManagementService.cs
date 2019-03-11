using Maintain.NET.Data;
using Maintain.NET.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Models.Services
{
    public class TaskManagementService : ITaskManager
    {
        private MaintainDbContext _context { get; }

        public TaskManagementService(MaintainDbContext context)
        {
            _context = context;
        }

        public async Task CreateTask (MaintenanceTask maintenanceTask)
        {
            _context.MaintenanceTasks.Add(maintenanceTask);
            await _context.SaveChangesAsync();
        }
    }
}
