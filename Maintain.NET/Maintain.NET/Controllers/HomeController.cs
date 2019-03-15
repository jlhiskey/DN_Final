using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Maintain.NET.Models;

namespace Maintain.NET.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Sends user to home page
        /// </summary>
        /// <returns>Home View</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Sends user to Register View
        /// </summary>
        /// <returns>Register View</returns>
        public IActionResult Register()
        {
            return RedirectToAction("Register", "Account");
        }

        /// <summary>
        /// Sends User to Login View
        /// </summary>
        /// <returns>Login View</returns>
        public IActionResult Login()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}