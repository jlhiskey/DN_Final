using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Models.Interfaces
{
    public interface ITaskManager
    {
        //create 
        Task CreateTask(MaintenanceTask maintenance);

        //read maintenance task
        Task<MaintenanceTask> GetTask(int id);

        //read all maintenance tasks
        Task<IEnumerable<MaintenanceTask>> GetAllTasks();

        //read a user's task
        Task<UserMaintenanceTask> GetUserMaintenanceTask(int id);

        //read all of a user's tasks
        Task<IEnumerable<UserMaintenanceTask>> GetAllUserMaintenanceTasks(int id);

        //update/edit
        Task UpdateTask(MaintenanceTask maintenanceTask);
        
        //delete
        Task DeleteTask(int id);

        bool TaskExists(int id);
    }
}
