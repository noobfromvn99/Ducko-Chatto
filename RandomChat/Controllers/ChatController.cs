using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomChat.Data;
using RandomChat.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RandomChat.Controllers
{
    public class ChatController : Controller
    {
        private readonly ChatContext _context;
        private ChatManger chatManger;

        public ChatController(ChatContext context)
        {
            _context = context;
            chatManger = ChatManger.getInstance();
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32(nameof(AppUser.UserID)) == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.city = HttpContext.Session.GetString("city");
                return View();
            }
        }

        public async Task<IActionResult> List(int? id)
        {
            Topic topic = _context.Topics.Find(id);
            var TopicItem = await chatManger.GetReply(id);
            ViewBag.replies = TopicItem.Items.OrderByDescending(e => e.ReplyOn);
            return View(topic);
        }

        [HttpPost]
        public async Task<IActionResult> Reply(int? TopicId, string content)
        {
            int? UserId = HttpContext.Session.GetInt32(nameof(AppUser.UserID));
            if (await chatManger.Send(TopicId, content, UserId))
            {
                return RedirectToAction("List", new { id = TopicId });
            }
            else
            {
                ModelState.AddModelError("Error", "Error when insertting your comment.");
                return RedirectToAction("List", new { id = TopicId });
            }

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string TopicName)
        {
            int UserId = Convert.ToInt32(HttpContext.Session.GetInt32(nameof(AppUser.UserID)));
            string location = HttpContext.Session.GetString("city");
            if (UserId == 0 || TopicName == null)
            {
                ModelState.AddModelError("Error", "Error when inserting your topic.");
                return View();
            }

            Topic topic = new Topic { TopicName = "#" + TopicName, UserId = UserId, Location = location };
            try
            {
                _context.Topics.Add(topic);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                ModelState.AddModelError("Error", "Error when inserting your topic. Your topic name might be token.");
            }
            return RedirectToAction("List", new { id = topic.TopicId });
        }


    }
}