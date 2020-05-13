using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomChat.Models;

namespace RandomChat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ChatContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
             _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public Task<IActionResult> Login(string UsrID, string Password, Gender Gender, ageStage AgeStage)
        {
            var login = await _context.Logins.FindAsync(loginID);
            //Validation
            if (login == null || !PBKDF2.Verify(login.PasswordHash, password))
            {
                ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
                return View(new Login { LoginID = loginID });
            }

            // Login customer.
            HttpContext.Session.SetInt32(nameof(Customer.CustomerID), login.UsrID);
            HttpContext.Session.SetString(Gender, Gender);
            HttpContext.Session.SetString(ageStage, AgeStage);
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
