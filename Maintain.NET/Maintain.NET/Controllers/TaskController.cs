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

namespace Maintain.NET.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskManager _context;
        private readonly IUserTaskManager _usertask;
        private UserManager<ApplicationUser> _userManager;
        private IEmailSender _emailSender;
        private EmailSender _mail;

        public TaskController(ITaskManager context, IUserTaskManager usertask, UserManager<ApplicationUser> userManager, IEmailSender emailSender, EmailSender mail)
        {
            _context = context;
            _usertask = usertask;
            _userManager = userManager;
            _emailSender = emailSender;
            _mail = mail;
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
            //ViewData["UserTaskID"] = new SelectList(allTask, "ID", "Name");
            return View(allTask);
        }

        //----------------------ASYNCINN REFERENCE BELOW TO POST USER TASK-------------------------------------

        [HttpPost]
        public async Task<IActionResult> Create(int id)
        {
            var isd = Int32.Parse(Request.Form["task"]);

            var user = _userManager.GetUserId(User);

            await _usertask.CreateUserTask(isd, user);
            //if (ModelState.IsValid)
            //{
            //    _context.Add(roomAmenities);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            return RedirectToAction("Index", "Task");
        }

        /// <summary>
        /// deletes task and returns user to task view page
        /// </summary>
        /// <param name="id">user task</param>
        /// <returns> task view page</returns>
        public async Task<IActionResult> DeleteUserTask(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _usertask.DeleteUserTask(id);

            return RedirectToAction("Index", "Task");
        }

         /// <summary>
         /// determines if a user task exist
         /// </summary>
         /// <param name="id"> user task id</param>
         /// <returns> true or false</returns>
        
        public async Task<IActionResult> Complete(int userTaskID)
        {
            //string userID = _userManager.GetUserId(User);
            //await _usertask.GetUserTask(userID, userTaskID);
            await _usertask.Complete(userTaskID);

            return RedirectToAction(nameof(Index));
        }

        public async Task AlertEmail(ApplicationUser user, int userTaskID)
        {
           var task = await _usertask.GetUserTask(user.Id, userTaskID);

            ApplicationUser thisUser = await _userManager.FindByEmailAsync(user.Email);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{task.MaintenanceTask.Name} is due {task.NextComplete}");
            sb.AppendLine("GET IT DONE!");
            await _mail.GetDate(task.NextComplete);

            await _emailSender.SendEmailAsync(thisUser.Email, "Task Alert", sb.ToString());
        }
        //------------------
    }
}