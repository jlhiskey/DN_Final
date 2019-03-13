using Maintain.NET.Data;
using Maintain.NET.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Models.Services
{
    public class UserTaskManagementService : IUserTaskManager
    {
        private MaintainDbContext _context { get; }

        public UserTaskManagementService(MaintainDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// allows user to select a task
        /// </summary>
        /// <param name="userMaintenanceTask"> </param>
        /// <returns></returns>
        public async Task CreateUserTask(MaintenanceTask maintenanceTask, string userId)
        {
            UserMaintenanceTask uMTask = new UserMaintenanceTask(userId, maintenanceTask.ID);
            uMTask.LastComplete = 0;
            uMTask.MaintenanceTask = maintenanceTask;
            uMTask.NextComplete = 0;
            uMTask.UserMaintenanceHistory = await _context.UserMaintenanceHistories.Where(h => h.UserID == userId).ToListAsync();
            
            _context.UserMaintenanceTasks.Add(uMTask);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// gets user task
        /// </summary>
        /// <param name="id"> int id</param>
        /// <returns>  returns task ID</returns>
        public async Task<UserMaintenanceTask> GetUserTask(string userId)
        {
            return await _context.UserMaintenanceTasks.FirstOrDefaultAsync(tsk => tsk.UserID == userId);
        }

        /// <summary>
        /// selects all user task
        /// </summary>
        /// <param name="id"> task id</param>
        /// <returns> returns all task ID</returns>
        public async Task<IEnumerable<UserMaintenanceTask>> GetAllUserTasks(string userId)
        {
            return await _context.UserMaintenanceTasks.ToListAsync();
        }

        //update/edit
        /// <summary>
        /// updates user task
        /// </summary>
        /// <param name="userMaintenanceTask"> user maintenance task</param>
        /// <returns> updated task</returns>
        public async Task UpdateUserTask(UserMaintenanceTask userMaintenanceTask)
        {
            _context.UserMaintenanceTasks.Update(userMaintenanceTask);
            await _context.SaveChangesAsync();
        }

        //delete
        /// <summary>
        /// deletes user task
        /// </summary>
        /// <param name="id"> task id</param>
        /// <returns> removes deleted task</returns>
        public async Task DeleteUserTask(int id)
        {
            var userMaintenanceTask = await _context.UserMaintenanceTasks.FindAsync(id);
            _context.Remove(userMaintenanceTask);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// checks to see if task exist
        /// </summary>
        /// <param name="id"> task id</param>
        /// <returns> returns a response if a task exist</returns>
        public bool UserTaskExists(int id)
        {
            return _context.UserMaintenanceTasks.Any(ex => ex.ID == id);
        }
    }
}
