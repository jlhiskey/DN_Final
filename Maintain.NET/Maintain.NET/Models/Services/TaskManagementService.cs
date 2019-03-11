using Maintain.NET.Data;
using Maintain.NET.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task CreateTask(MaintenanceTask maintenanceTask)
        {
            _context.MaintenanceTasks.Add(maintenanceTask);
            await _context.SaveChangesAsync();
        }

        public async Task<MaintenanceTask> GetTask(int id)
        {
            return await _context.MaintenanceTasks.FirstOrDefaultAsync(tsk => tsk.ID == id);
        }
     
        public async Task<IEnumerable<MaintenanceTask>> GetAllUserTasks()
        {
            return await _context.MaintenanceTasks.ToListAsync();
        }

        //update/edit
        public async Task UpdateTask(MaintenanceTask maintenanceTask)
        {
            _context.MaintenanceTasks.Update(maintenanceTask);
            await _context.SaveChangesAsync();
        }

        //delete
        public async Task DeleteTask(int id)
        {
            MaintenanceTask maintenanceTask = await _context.MaintenanceTasks.FindAsync(id);
        }

        public bool TaskExists(int id)
        {
            return _context.MaintenanceTasks.Any(ex => ex.ID == id);
        }
    }
}
