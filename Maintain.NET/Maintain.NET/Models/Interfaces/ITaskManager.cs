using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Models.Interfaces
{
    interface ITaskManager
    {
        //create 
        Task CreateTask();

        //read maintenance task
        Task<MaintenanceTask> GetTask(int id);

        //read all maintenance tasks
        Task<IEnumerable<MaintenanceTask>> GetAllTasks();

        //read a user's task
        Task<UserMaintenanceTask> GetUserMaintenanceTask(int id);

        //read all of a user's tasks
        Task<UserMaintenanceTask> GetAllUserMaintenanceTasks(int id);

        //update/edit
        Task UpdateTask();

        //delete
        Task DeleteTask(int id);

        bool TaskExists(int id);
    }
}
