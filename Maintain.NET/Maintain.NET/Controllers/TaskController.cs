using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Maintain.NET.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskManager _context;

        public TaskController(ITaskManager context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}