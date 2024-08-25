using Domain.Users;
using Endpoint.Models.ViewModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Website.Endpoint2.Utilitis.Filters;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Endpoint.Controllers
{
    [ServiceFilter(typeof(SaveVisitorFilter))]

    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> uerManager, SignInManager<User> signInManager)
        {
            _userManager = uerManager;
            _signInManager = signInManager;

        }
        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _userManager.FindByNameAsync(model.Email).Result;
            if (user == null)
            {
                ModelState.AddModelError("", "کاربر یافت نشد");
                return View(model);
            }
            _signInManager.SignOutAsync();
            var result = _signInManager.PasswordSignInAsync(user, model.Password, model.IsPersitent, true).Result;
            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl);
            }
            return View(model);
        }
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User newUser = new User()
            {
                Email = model.Email,
                UserName = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber
            };
            var result = _userManager.CreateAsync(newUser, model.Password).Result;
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Profile));
            }
           
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }
            return View(model);
           
        }
    
        public IActionResult Profile()
        {
            return View();
        }
    }
}
