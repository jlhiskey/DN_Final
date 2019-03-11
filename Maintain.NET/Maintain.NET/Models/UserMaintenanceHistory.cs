using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Models
{
    public class UserMaintenanceHistory
    {
        public int ID { get; set; }

        /// <summary>
        /// User ID
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// User Maintenance Task ID
        /// </summary>
        public int UserMaintenanceTaskID { get; set; }

        /// <summary>
        /// Records when the task was completed
        /// </summary>
        public DateTime TimeComplete { get; set; }

        // Navigation Properties

        public UserMaintenanceTask UserMaintenanceTask { get; set; }
    }
}
