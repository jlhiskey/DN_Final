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
        /// allows user to create a task
        /// </summary>
        /// <param name="maintenanceTaskID">Selected Maintenance Task</param>
        /// <param name="userId">Current User</param>
        /// <returns>Adds new User Task to Database</returns>
        public async Task CreateUserTask(int maintenanceTaskID, string userId)
        {
            TimeConverter timeConverter = new TimeConverter();

            MaintenanceTask task = _context.MaintenanceTasks.FirstOrDefault(m => m.ID == maintenanceTaskID);
            UserMaintenanceTask uMTask = new UserMaintenanceTask(userId, maintenanceTaskID);
            uMTask.LastComplete = timeConverter.DateToUnix(DateTime.Now);
            uMTask.MaintenanceTask = task;
            uMTask.NextComplete = uMTask.LastComplete + task.RecommendedInterval;
            uMTask.UserMaintenanceHistory = await _context.UserMaintenanceHistories.Where(h => h.UserID == userId).ToListAsync();
            
            _context.UserMaintenanceTasks.Add(uMTask);
            await _context.SaveChangesAsync();
        }

       /// <summary>
       /// Retreives a specific UserMaintenanceTask from database using user id and user maintenance task ID
       /// </summary>
       /// <param name="userId"></param>
       /// <param name="userMaintenanceTaskID"></param>
       /// <returns>Selected UserMaintenanceTask</returns>
        public async Task<UserMaintenanceTask> GetUserTask(string userId, int userMaintenanceTaskID)
        {
            UserMaintenanceTask task = await _context.UserMaintenanceTasks.FirstOrDefaultAsync(tsk => tsk.ID == userMaintenanceTaskID);
            task.MaintenanceTask = await _context.MaintenanceTasks.FirstOrDefaultAsync(t => t.ID == task.MaintenanceTaskID);
            task.UserMaintenanceHistory = await _context.UserMaintenanceHistories.Where(h => h.UserMaintenanceTaskID == userMaintenanceTaskID).Take(10).ToListAsync();
            return task;
        }

        /// <summary>
        /// selects all user task
        /// </summary>
        /// <param name="userId"> user id</param>
        /// <returns> returns all task ID</returns>
        public async Task<IEnumerable<UserMaintenanceTask>> GetAllUserTasks(string userId)
        {
            var tasks = await _context.UserMaintenanceTasks.Where(i => i.UserID == userId).ToListAsync();
            foreach (var i in tasks)
            {
                i.MaintenanceTask = await _context.MaintenanceTasks.FirstOrDefaultAsync(m => m.ID== i.MaintenanceTaskID);
            }
            return tasks;
        }

       
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
        /// <param name="userTaskID"> task id</param>
        /// <returns> removes deleted task</returns>
        public async Task DeleteUserTask(int userTaskID)
        {
            var userMaintenanceTask = await _context.UserMaintenanceTasks.FirstOrDefaultAsync(umt => umt.ID == userTaskID);
            _context.Remove(userMaintenanceTask);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// checks to see if task exist
        /// </summary>
        /// <param name="userMaintenanceTaskID"> task id</param>
        /// <returns> returns a response if a task exist</returns>
        public bool UserTaskExists(int userMaintenanceTaskID)
        {
            return _context.UserMaintenanceTasks.Any(ex => ex.ID == userMaintenanceTaskID);
        }

        /// <summary>
        /// Updates a UserMaintenenceTasks LastComplete property and creates a new userMaintenanceHistory item with interval data and then calls UpdateMaintenanceTaskInterval 
        /// </summary>
        /// <param name="userTaskID">User Task ID</param>
        /// <returns></returns>
        public async Task Complete(int userTaskID)
        {
            TimeConverter timeConverter = new TimeConverter();

            UserMaintenanceTask userMaintenanceTask = await _context.UserMaintenanceTasks.FirstOrDefaultAsync(umt => umt.ID == userTaskID);
            long lastComplete = userMaintenanceTask.LastComplete;
            userMaintenanceTask.LastComplete = timeConverter.DateToUnix(DateTime.Now);

            _context.Update(userMaintenanceTask);
            
            long interval = timeConverter.CalculateInterval(lastComplete);
            
            MaintenanceTask maintenanceTask = await _context.MaintenanceTasks.FirstOrDefaultAsync(mt => mt.ID == userMaintenanceTask.MaintenanceTaskID);

            UserMaintenanceHistory userMaintenanceHistory = new UserMaintenanceHistory();
            userMaintenanceHistory.UserID = userMaintenanceTask.UserID;
            userMaintenanceHistory.TimeComplete = DateTime.Now;
            userMaintenanceHistory.MaintenanceRef = maintenanceTask.ID;
            userMaintenanceHistory.Interval = interval;            

            _context.Add(userMaintenanceHistory);

            await _context.SaveChangesAsync();

            await UpdateMaintenanceTaskInterval(userMaintenanceTask.ID);
        }

        /// <summary>
        /// Collects all UserMaintenanceHistories that match the maintenaceID of the userTask then runs all of the received interval data through an algorithm that will determine a new recommended interval for the master MaintenanceTask that is related to the UserMaintenanceTask, it then updates the userTasks NextComplete value.
        /// </summary>
        /// <param name="userTaskID">User Task ID</param>
        /// <returns>Updates UserTask.NextComplete</returns>
        public async Task UpdateMaintenanceTaskInterval(int userTaskID)
        {
            UserMaintenanceTask userMaintenanceTask = await _context.UserMaintenanceTasks.FirstOrDefaultAsync(umt => umt.ID == userTaskID);
            MaintenanceTask maintenanceTask = await _context.MaintenanceTasks.FirstOrDefaultAsync(mt => mt.ID == userMaintenanceTask.MaintenanceTaskID);

            var allExistingMaintenanceHistory = await _context.UserMaintenanceHistories.ToListAsync();
         
            IEnumerable<UserMaintenanceHistory> allMaintenanceHistory = _context.UserMaintenanceHistories.Where(umh => umh.MaintenanceRef == maintenanceTask.ID);
            
            if(allMaintenanceHistory.Count() > 0)
            {
                maintenanceTask.RecommendedInterval = MachineLearning.Run(allMaintenanceHistory, maintenanceTask.MinimumInterval, maintenanceTask.MaximumInterval);
            }
            userMaintenanceTask.NextComplete = userMaintenanceTask.LastComplete + maintenanceTask.RecommendedInterval;
            _context.Update(userMaintenanceTask);
            _context.Update(maintenanceTask);

            await _context.SaveChangesAsync();
        }
        
    }
}
