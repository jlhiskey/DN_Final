using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Models
{
    public class UserMaintenanceTask
    {

        public int ID { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// MaintenanceTaskID
        /// </summary>
        public int MaintenanceTaskID { get; set; }

        /// <summary>
        /// Last time that the task was completed.
        /// </summary>
        public int LastComplete { get; set; }

        /// <summary>
        /// Current time that the task has completed.
        /// </summary>
        public int NextComplete { get; set; }

        // Navigation Properties

        public MaintenanceTask MaintenanceTask { get; set; }

        /// <summary>
        /// Collection of All Users MaintenanceHistory matching their maintenance task.
        /// </summary>
        public ICollection<UserMaintenanceHistory> UserMaintenanceHistory { get; set; }

        /// <summary>
        /// Creates a new UserMaintainanceTask using inputs of userID and maintenanceTaskID.
        /// </summary>
        /// <param name="userID">ID of user creating user task.</param>
        /// <param name="maintenanceTaskID">ID of maintenance task ID associated with user task</param>
        public UserMaintenanceTask(string userID, int maintenanceTaskID)
        {
            UserID = userID;
            MaintenanceTaskID = maintenanceTaskID;
        }
    }
}
