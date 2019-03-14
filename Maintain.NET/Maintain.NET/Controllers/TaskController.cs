using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Maintain.NET.Data;
using Maintain.NET.Models;
using Maintain.NET.Models.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Text;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Authorization;

namespace Maintain.NET.Controllers
{   
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskManager _context;
        private readonly IUserTaskManager _usertask;
        private UserManager<ApplicationUser> _userManager;
        private IEmailSender _emailSender;
        

        public TaskController(ITaskManager context, IUserTaskManager usertask, UserManager<ApplicationUser> userManager, IEmailSender emailSender)
        {
            _context = context;
            _usertask = usertask;
            _userManager = userManager;
            _emailSender = emailSender;          
        }

        /// <summary>
        /// returns the all of the user task on the index page
        /// </summary>
        /// <returns> returns a view of task</returns>
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            var tasks = await _usertask.GetAllUserTasks(userId);
            return View(tasks);
        }

        /// <summary>
        /// Takes user to manage page
        /// </summary>
        /// <param name="userTaskID"></param>
        /// <returns>Manage page</returns>
        public async Task<IActionResult> Manage(int userTaskID)
        {
            string userID = _userManager.GetUserId(User);
            UserMaintenanceTask userMaintenanceTask = await _usertask.GetUserTask(userID, userTaskID);
            return View(userMaintenanceTask);
        }

        /// <summary>
        /// gets list of task in drop down
        /// </summary>
        /// <returns> returns list in drop down in the view</returns>
        [HttpGet]
        public async Task<IActionResult> CreateUserTask()
        {
            var allTask = await _context.GetAllTasks();
            
            return View(allTask);
        }

        /// <summary>
        /// Creates a new user task
        /// </summary>
        /// <param name="id">Task ID</param>
        /// <returns>View user dashboard</returns>
        [HttpPost]
        public async Task<IActionResult> Create(int id)
        {
            var isd = Int32.Parse(Request.Form["task"]);

            var user = _userManager.GetUserId(User);

            await _usertask.CreateUserTask(isd, user);
            
            return RedirectToAction("Index", "Task");
        }

        /// <summary>
        /// deletes task and returns user to task view page
        /// </summary>
        /// <param name="userTaskID">user task</param>
        /// <returns> task view page</returns>
        public async Task<IActionResult> DeleteUserTask(int userTaskID)
        {
            
            await _usertask.DeleteUserTask(userTaskID);

            return RedirectToAction("Index", "Task");
        }

         /// <summary>
         /// determines if a user task exist
         /// </summary>
         /// <param name="id"> user task id</param>
         /// <returns> true or false</returns>
        private bool UserTaskExist(int id)
        {
            return _usertask.UserTaskExists(id);
        }

        /// <summary>
        /// Marks a taks complete
        /// </summary>
        /// <param name="userTaskID"></param>
        /// <returns>Manage page</returns>
        public async Task<IActionResult> Complete(int userTaskID)
        {
            var user = await _userManager.GetUserAsync(User);

            await _usertask.Complete(userTaskID);
            await AlertEmail(user, userTaskID);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Compiles email notification
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userTaskID"></param>
        /// <returns></returns>
        public async Task AlertEmail(ApplicationUser user, int userTaskID)
        {
            TimeConverter timeConverter = new TimeConverter();
            ApplicationUser thisUser = await _userManager.FindByEmailAsync(user.Email);

            var task = await _usertask.GetUserTask(user.Id, userTaskID);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{task.MaintenanceTask.Name} is due {timeConverter.UnixToDate(task.NextComplete)}!");

            sb.AppendLine("GET IT DONE!");

            await _emailSender.SendEmailAsync(thisUser.Email, "TASK DUE", sb.ToString());
        }
    }
}