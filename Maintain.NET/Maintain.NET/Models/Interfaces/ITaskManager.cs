using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Models.Interfaces
{
    public interface ITaskManager
    {
        //create 
        Task CreateTask(MaintenanceTask maintenanceTask);

        //read maintenance task
        Task<MaintenanceTask> GetTask(int id);

        //read all maintenance tasks
        Task<IEnumerable<MaintenanceTask>> GetAllTasks();

        //update/edit
        Task UpdateTask(MaintenanceTask maintenanceTask);
        
        //delete
        Task DeleteTask(int id);
        
        bool TaskExists(int id);
    }
}
