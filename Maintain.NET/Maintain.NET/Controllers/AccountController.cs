﻿using Maintain.NET.Models;
using Maintain.NET.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public async Task<IActionResult> Register(LoginViewModel rvm)
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

                //runs create method
                var result = await _userManager.CreateAsync(user, rvm.Password);

                if (result.Succeeded)
                {
                    //adds claims for full name
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    List<Claim> claims = new List<Claim> { fullNameClaim };

                    await _userManager.AddClaimsAsync(user, claims);

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }
                

                return View(rvm);
            }

            return View(rvm);
        }

        /// <summary>
        /// directs user to login page
        /// </summary>
        /// <returns>login view</returns>
        [HttpGet]
        public IActionResult Login() => View();

        /// <summary>
        /// Gets email and password from user and logs them in
        /// </summary>
        /// <param name="lvm">Email and Password</param>
        /// <returns>User Profile View</returns>
        [HttpPost]
        public async Task<IActionResult> Login(LogInViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            return View(lvm);
        }
    }
}