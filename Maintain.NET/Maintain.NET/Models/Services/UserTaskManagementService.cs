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
        public async Task CreateUserTask(int id, string userId)
        {
            MaintenanceTask task = _context.MaintenanceTasks.FirstOrDefault(m => m.ID == id);
            UserMaintenanceTask uMTask = new UserMaintenanceTask(userId, id);
            uMTask.LastComplete = 0;
            uMTask.MaintenanceTask = task;
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
            var tasks = await _context.UserMaintenanceTasks.ToListAsync();
            foreach (var i in tasks)
            {
                i.MaintenanceTask = await _context.MaintenanceTasks.FirstOrDefaultAsync(m => m.ID == i.ID);
            }
            return tasks;
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
        //----------------------
        public async Task CompleteTask(int userTaskID)
        {
            UserMaintenanceTask userMaintenanceTask = await _context.UserMaintenanceTasks.FirstOrDefaultAsync(umt => umt.ID == userTaskID);
            long lastComplete = userMaintenanceTask.LastComplete;
            

            TimeConverter timeConverter = new TimeConverter();

            long interval = timeConverter.CalculateInterval(lastComplete);
            userMaintenanceTask.LastComplete = timeConverter.DateToUnix(DateTime.Now);

            MaintenanceTask maintenanceTask = await _context.MaintenanceTasks.FirstOrDefaultAsync(mt => mt.ID == userMaintenanceTask.MaintenanceTaskID);

            UserMaintenanceHistory userMaintenanceHistory = new UserMaintenanceHistory();
            userMaintenanceHistory.UserID = userMaintenanceTask.UserID;
            userMaintenanceHistory.TimeComplete = DateTime.Now;
            userMaintenanceHistory.MaintenanceTaskID = maintenanceTask.ID;
        }

        public async Task UpdateMaintenanceTaskInterval(int userTaskID)
        {
            UserMaintenanceTask userMaintenanceTask = await _context.UserMaintenanceTasks.FirstOrDefaultAsync(umt => umt.ID == userTaskID);
            MaintenanceTask maintenanceTask = await _context.MaintenanceTasks.FirstOrDefaultAsync(mt => mt.ID == userMaintenanceTask.MaintenanceTaskID);
            //var allMaintenanceHistory = await _context.UserMaintenanceHistories.Select(umh => umh.MaintenanceTaskID == maintenanceTask.ID);

        }
        //----------------------
    }
}
