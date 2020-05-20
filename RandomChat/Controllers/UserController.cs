using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomChat.Attributes;
using RandomChat.Data;
using RandomChat.Models;

namespace RandomChat.Controllers
{
    [AuthorizeUser]
    public class UserController : Controller
    {
        private readonly ChatContext _context;
        private readonly ChatManger chatManger;

        public UserController(ChatContext context)
        {
            _context = context;
            chatManger = ChatManger.getInstance();
        }

        [Route("/profile")]
        public async Task<IActionResult> IndexAsync()
        {
            var id = HttpContext.Session.GetInt32(nameof(AppUser.UserID));
            AppUser user = _context.Appusers.Find(id);
            var TopicItem = await chatManger.GetReply(id);
            ViewBag.replies = TopicItem.Items.OrderByDescending(e => e.ReplyOn);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete() 
        {
            Console.WriteLine("Delete");
            var id = HttpContext.Session.GetInt32(nameof(AppUser.UserID));
            AppUser user = _context.Appusers.Find(id);
            Login login = _context.Logins.Find(user.Login);
            login.Activate = false;
            _context.SaveChanges();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}