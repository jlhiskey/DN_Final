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

namespace Maintain.NET.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskManager _context;
        private readonly IUserTaskManager _usertask;


        public TaskController(ITaskManager context, IUserTaskManager usertask)
        {
            _context = context;
            _usertask = usertask;
        }

        /// <summary>
        /// returns the all of the user task on the index page
        /// </summary>
        /// <returns> returns a view of task</returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAllTasks());
        }

        /// <summary>
        /// gets list of task in drop down
        /// </summary>
        /// <returns> returns list in drop down in the view</returns>
        public async Task<IActionResult> Create()
        {
            var allTask = await _context.GetAllTasks();
            ViewData["UserTaskID"] = new SelectList(allTask, "ID", "Name");
            return View();
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

            var task = await _usertask.GetUserTask(id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
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



    }
}