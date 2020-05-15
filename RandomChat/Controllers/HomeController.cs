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
            if (HttpContext.Session.GetInt32(nameof(AppUser.UserID)) != null)
            {
                return RedirectToAction("Index", "Chat");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Email, string Password, string Gender, string AgeStage)
        {
            var login = await _context.Logins.FindAsync(Email);
            var user = _context.Appusers.Where(e => e.Email == Email).Single();
            //Validation
            if (login == null || !PBKDF2.Verify(login.PasswordHash, Password))
            {
                ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
                return View(new Login { Email = Email });
            }

            // Login customer.
            HttpContext.Session.SetInt32(nameof(AppUser.UserID), user.UserID);
            HttpContext.Session.SetString("Gender", Gender.ToString());
            HttpContext.Session.SetString("ageStage", AgeStage.ToString());
            return RedirectToAction("Index", "Chat");
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> CreateAsync(string email, string password)
        {
            
            Login login = new Login { Email = email,  PasswordHash = PBKDF2.Hash(password) };
            _context.Logins.Add(login);
            AppUser user = new AppUser { Email = login.Email };
            _context.Appusers.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
