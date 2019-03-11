using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Maintain.NET.Data;
using Maintain.Net.Models;
using Maintain.NET.Models.Interfaces;

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