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
            UserMaintenanceHistory one = new UserMaintenanceHistory();
            one.Interval = 2;

            UserMaintenanceHistory two = new UserMaintenanceHistory();
            one.Interval = 4;

            UserMaintenanceHistory three = new UserMaintenanceHistory();
            one.Interval = 6;

            UserMaintenanceHistory four = new UserMaintenanceHistory();
            one.Interval = 1;

            UserMaintenanceHistory five = new UserMaintenanceHistory();
            one.Interval = 5;

            List<UserMaintenanceHistory> list = new List<UserMaintenanceHistory>() { one, two, three, four, five };

            MachineLearning.Run(list, 1, 5);


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

        public IActionResult Test()
        {
            



            return View();
        }
    }
}