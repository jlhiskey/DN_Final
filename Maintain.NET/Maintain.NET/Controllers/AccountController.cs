using Maintain.NET.Models;
using Maintain.NET.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maintain.NET.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;

        private SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;

            _signInManager = signInManager;
        }
        /// <summary>
        /// Resgistration Page
        /// </summary>
        /// <returns>View to registration page</returns>
        [HttpGet]
        public IActionResult Register() => View();

        /// <summary>
        /// Sends View model to register view
        /// </summary>
        /// <param name="rvm">RegisterViewModel</param>
        /// <returns>View Model to register view</returns>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                //Create application user
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = rvm.Email,

                    Email = rvm.Email,

                    FirstName = rvm.FirstName,

                    LastName = rvm.LastName
                };

                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }


                return View(rvm);
            }

            return View(rvm);
        }
    }
}
