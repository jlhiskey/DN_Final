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
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public TaskManagementService(MaintainDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// saves added task by user
        /// </summary>
        /// <param name="maintenanceTask"> task</param>
        /// <returns>returns added task</returns>
        public async Task CreateTask(MaintenanceTask maintenanceTask)
        {
            _context.MaintenanceTasks.Add(maintenanceTask);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// gets task selected by user
        /// </summary>
        /// <param name="id">task id</param>
        /// <returns> returns task ID</returns>
        public async Task<MaintenanceTask> GetTask(int id)
        {
            return await _context.MaintenanceTasks.FirstOrDefaultAsync(tsk => tsk.ID == id);
        }
     
        /// <summary>
        ///  gets all the task 
        /// </summary>
        /// <returns> returns all the task</returns>
        public async Task<IEnumerable<MaintenanceTask>> GetAllTasks()
        {
            return await _context.MaintenanceTasks.ToListAsync();
        }

        /// <summary>
        /// allows user to add task to their dashboard
        /// </summary>
        /// <param name="maintenanceTask"> maintenance task</param>
        /// <returns> returns the chosen task </returns>
        public async Task UpdateTask(MaintenanceTask maintenanceTask)
        {
            _context.MaintenanceTasks.Update(maintenanceTask);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// alow user to delete task
        /// </summary>
        /// <param name="id"> task id</param>
        /// <returns> returns nothing because the task is deleted</returns>
        public async Task DeleteTask(int id)
        {
            MaintenanceTask maintenanceTask = await _context.MaintenanceTasks.FindAsync(id);
        }

        /// <summary>
        /// checks to see if task exist
        /// </summary>
        /// <param name="id"> task id</param>
        /// <returns> returns if the task exist</returns>
        public bool TaskExists(int id)
        {
            return _context.MaintenanceTasks.Any(ex => ex.ID == id);
        }
    }
}
