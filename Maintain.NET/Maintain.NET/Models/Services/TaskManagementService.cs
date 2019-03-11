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

        public async Task CreateTask (MaintenanceTask maintenanceTask)
        {
            _context.MaintenanceTasks.Add(maintenanceTask);
            await _context.SaveChangesAsync();
        }

        public async Task<MaintenanceTask> GetTask(int id)
        {
            return await _context.MaintenanceTasks.FirstOrDefaultAsync(tsk => tsk.ID == id);
        }
     
        public async Task<IEnumerable<MaintenanceTask>> GetAllTasks()
        {
            return await _context.MaintenanceTasks.ToListAsync();
        }

        public async Task<UserMaintenanceTask> GetUserMaintenanceTask(int id)
        {
            return await _context.UserMaintenanceTasks.FirstOrDefaultAsync(tsk => tsk.ID == id);
        }

        public async Task<IEnumerable<UserMaintenanceTask>> GetAllUserMaintenanceTasks(int id)
        {
            return await _context.UserMaintenanceTasks.ToListAsync();
        }

        //update/edit
        public async Task UpdateTask(MaintenanceTask maintenanceTask)
        {
            _context.MaintenanceTasks.Update(maintenanceTask);
            await _context.SaveChangesAsync();
        }

        //delete
        Task DeleteTask(int id);

        bool TaskExists(int id);
    }
}
