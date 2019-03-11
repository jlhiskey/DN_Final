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

        public async Task CreateUserTask(UserMaintenanceTask userMaintenanceTask)
        {
            _context.UserMaintenanceTasks.Add(userMaintenanceTask);
            await _context.SaveChangesAsync();
        }

        public async Task<UserMaintenanceTask> GetUserTask(int id)
        {
            return await _context.UserMaintenanceTasks.FirstOrDefaultAsync(tsk => tsk.ID == id);
        }

        public async Task<IEnumerable<UserMaintenanceTask>> GetAllUserTasks(int id)
        {
            return await _context.UserMaintenanceTasks.ToListAsync();
        }

        //update/edit
        public async Task UpdateUserTask(UserMaintenanceTask userMaintenanceTask)
        {
            _context.UserMaintenanceTasks.Update(userMaintenanceTask);
            await _context.SaveChangesAsync();
        }

        //delete
        public async Task DeleteUserTask(int id)
        {
            UserMaintenanceTask userMaintenanceTask = await _context.UserMaintenanceTasks.FindAsync(id);
        }

        public bool UserTaskExists(int id)
        {
            return _context.UserMaintenanceTasks.Any(ex => ex.ID == id);
        }
    }
}
