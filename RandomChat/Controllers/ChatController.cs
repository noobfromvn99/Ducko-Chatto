using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        private const string bucketName = "ducko-chatto-image-store";
        private const string keyName = "image";
        private const string filePath = "C:\\Users\\Bach Rach\\Desktop\\79934978_2536034256721619_1821982627985358848_o.jpg";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;
        private static IAmazonS3 s3Client;
        public ChatController(ChatContext context)
        {
            _context = context;
            chatManger = ChatManger.getInstance();
            s3Client = new AmazonS3Client(bucketRegion);
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
        public async Task<IActionResult> CreateAsync(string TopicName)
        {
            try
            {
                var fileTransferUtility = new TransferUtility(s3Client);
                await fileTransferUtility.UploadAsync(filePath, bucketName);
            }
            catch (AmazonS3Exception e)
            {
                ModelState.AddModelError("Error", "Error encountered on server. Message: " + e.Message + " when writing an object");
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Error", "Unknown encountered on server. Message: "+ e.Message + " when writing an object" );
            
            }

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