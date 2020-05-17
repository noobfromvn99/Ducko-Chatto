using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RandomChat.Data;
using RandomChat.Models;

namespace RandomChat.Controllers
{
    public class PostPartialController : Controller
    {
        private readonly ChatContext _context;
        public static int PICKED = 5;
        public PostPartialController(ChatContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ReList()
        {
            int count = _context.Topics.Count();

            List<Topic> topics = _context.Topics.OrderBy(r => Guid.NewGuid()).Take(PICKED).ToList();
            

            return PartialView("_ReList", topics);
        }

        [HttpGet]
        public IActionResult Search(string content) 
        {
            List<Topic> topics = _context.Topics.Where(e => e.TopicName.Contains(content)).ToList();

            return PartialView("_ReList", topics);
        }
    }
}