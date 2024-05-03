﻿using Foodies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Foodies.Controllers
{
	public class AdminController : Controller
	{
		private readonly ApplicationDBContext _DBContetx;
		public AdminController(ApplicationDBContext dbContetx)
		{
			_DBContetx = dbContetx;
		}
		public IActionResult Index()
		{
			return View();
		}
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var admin = _DBContetx.Admins.FirstOrDefault(a => a.Email == email && a.Password == password);
                if (admin != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid email or password");
                }
            }
            return View();
        }
    }
}
