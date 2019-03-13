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

namespace Maintain.NET.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskManager _context;
        private readonly IUserTaskManager _usertask;
        private UserManager<ApplicationUser> _userManager;

        public TaskController(ITaskManager context, IUserTaskManager usertask, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usertask = usertask;
            _userManager = userManager;
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

        public IActionResult Manage()
        {
            return View();
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
            //var isd = Int32.Parse(Request.Form["task"]);

            await _usertask.DeleteUserTask(id);

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

        //public IActionResult Index()
        //{

        //// dropdown stuff....maybe
        //List<MaintenanceTask> tasklist = new List<MaintenanceTask>();

        //    // getting Data from database using entity framwork core
        //    tasklist = (from task in _context.MaintenanceTask select task).ToList();

        //    // inserting select Item in list
        //    tasklist.Insert(0, new MaintenanceTask { ID = 0, "Select" });

        //    ViewBag.ListofTask = tasklist;
        //}
        //------------------
        public async Task<IActionResult> Complete(int userTaskID, string userID)
        {
            await _usertask.GetUserTask(userID);

            return RedirectToAction(nameof(Index));
        }
        //------------------
    }
}