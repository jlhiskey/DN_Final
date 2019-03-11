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

     
        Task<IEnumerable<MaintenanceTask>> GetAllTasks();

        //read a user's task
        Task<UserMaintenanceTask> GetUserMaintenancTask(int id);

        //read all of a user's tasks
        Task<UserMaintenanceTask> GetAllUserMaintenanceTasks(int id);

        //update/edit
        Task UpdateTask();

        //delete
        Task DeleteTask(int id);

        bool TaskExists(int id);
    }
}
