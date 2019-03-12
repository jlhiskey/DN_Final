using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Models.Interfaces
{
    public interface IUserTaskManager
    {
        //create 
        Task CreateUserTask(UserMaintenanceTask userMaintenanceTask);

        //read a user's task
        Task<UserMaintenanceTask> GetUserTask(string userId);

        //read all of a user's tasks
        Task<IEnumerable<UserMaintenanceTask>> GetAllUserTasks(string userId);

        //update/edit
        Task UpdateUserTask(UserMaintenanceTask userMaintenanceTask);

        //delete
        Task DeleteUserTask(int id);

        bool UserTaskExists(int id);
    }
}
