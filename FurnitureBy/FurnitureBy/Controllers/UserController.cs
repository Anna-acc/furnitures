using FurnitureBy.Models;
using FurnitureBy.Services.Interfaces;
using FurnitureBy.Services.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FurnitureBy.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserAuthModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.CheckUser(userModel.Login, userModel.Password);
                if (user != null)
                {
                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(userModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Mode = "Register";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto user)
        {
            if (ModelState.IsValid)
            {
                user.IsActive = true;
                user.IsConfirm = true;

                await _userService.AddUser(user);

                return RedirectToAction("Login", "User");
            }

            ViewBag.Mode = "Register";
            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            ViewBag.Mode = "Profile";
            var user = await _userService.GetUser(User.Identity.Name);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserDto user)
        {
            if (ModelState.IsValid)
            {
                await _userService.EditUser(user);

                return RedirectToAction("Profile", "User");
            }

            ViewBag.Mode = "Profile";
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            var model = await _userService.GetAllUsers();

            return View(model);
        }

        public async Task<IActionResult> Add()
        {
            ViewBag.Mode = "Add";

            ViewBag.Roles = new SelectList(await _userService.GetAllRoles(), "Id", "Name");
            return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserDto user)
        {
            if (ModelState.IsValid)
            {
                user.IsActive = true;

                await _userService.AddUser(user);

                return RedirectToAction("AllUsers", "User");
            }

            ViewBag.Mode = "Add";
            ViewBag.Roles = new SelectList(await _userService.GetAllRoles(), "Id", "Name", user.RoleId);
            return View("Register", user);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string login)
        {
            var user = await _userService.GetUser(login);

            ViewBag.Mode = "Edit";
            ViewBag.Roles = new SelectList(await _userService.GetAllRoles(), "Id", "Name", user.RoleId);
            return View("Profile", user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserDto user)
        {
            if (ModelState.IsValid)
            {
                await _userService.EditUser(user);

                return RedirectToAction("AllUsers", "User");
            }

            ViewBag.Mode = "Edit";
            ViewBag.Roles = new SelectList(await _userService.GetAllRoles(), "Id", "Name", user.RoleId);
            return View("Profile", user);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string password, string confirmPassword, string login)
        {
            if (string.IsNullOrEmpty(password))
            {
                return Json(new { result = false, message = "Введите новый пароль" });
            }
            if (string.IsNullOrEmpty(confirmPassword))
            {
                return Json(new { result = false, message = "Подтвердите новый пароль" });
            }
            if (password != confirmPassword)
            {
                return Json(new { result = false, message = "Пароли не совпадают" });
            }

            var user = await _userService.GetUser(login);
            user.Password = password;

            await _userService.EditUser(user);

            return Json(new { result = true, message = "" });
        }

        [HttpGet]
        public async Task<IActionResult> Details(string login)
        {
            var user = await _userService.GetUser(login);

            return View(user);
        }

        private async Task Authenticate(UserDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.RoleId.ToString())
            };
            
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
