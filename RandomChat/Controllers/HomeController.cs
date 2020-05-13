using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomChat.Data;
using RandomChat.Models;
using SimpleHashing;

namespace RandomChat.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ChatContext _context;

        public HomeController(ChatContext context)
        {
         
             _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string UsrID, string Password, string Gender, string AgeStage)
        {
            var login = await _context.Logins.FindAsync(UsrID);
            //Validation
            if (login == null || !PBKDF2.Verify(login.PasswordHash, Password))
            {
                ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
                return View();
            }

            // Login customer.
            HttpContext.Session.SetInt32(nameof(Login.UsrID), login.UsrID);
            HttpContext.Session.SetString("Gender", Gender.ToString());
            HttpContext.Session.SetString("ageStage", AgeStage.ToString());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
