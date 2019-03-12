using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Models
{
    public class MaintenanceTask
    {
        public int ID { get; set; }

        /// <summary>
        /// Name of MaintenanceTask
        /// </summary>
        [Required(ErrorMessage = "Please provide a name for your task")]
        [Display(Name = "Task Name")]
        public string Name { get; set; }

        /// <summary>
        /// Recommended maintenance interval of MaintenanceTask
        /// </summary>
        [Display(Name = "Recommended Interval")]
        public long RecommendedInterval { get; set; }

        // Navigation Properties
        /// <summary>
        /// Collection of UserMaintenanceTasks based off of ID
        /// </summary>
        public ICollection<UserMaintenanceTask> UserMaintenanceTasks { get; set; }

        /// <summary>
        /// Creates a new MaintenanceTask with input name.
        /// </summary>
        /// <param name="name">string input that will set the Name of the new MaintenanceTask</param>
        public MaintenanceTask(string name)
        {
            Name = name;
        }

    }
}
