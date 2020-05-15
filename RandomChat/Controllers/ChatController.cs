using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomChat.Data;
using RandomChat.Models;

namespace RandomChat.Controllers
{
    public class ChatController : Controller
    {
        private readonly ChatContext _context;
        private ChatManger chatManger;

        public ChatController(ChatContext context) {
            _context = context;
            chatManger = new ChatManger();
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32(nameof(AppUser.UserID)) == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Gender = HttpContext.Session.GetString("Gender");
                chatManger.CreateTestTable();
                return View();
            }
        }
    }
}