using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
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
        // ConfigurationSetName = configSet argument below. 
        
        static readonly string senderAddress = "bach.rmit.5499@gmail.com";
        static readonly string subject = "Amazon SES test (AWS SDK for .NET)";
        private readonly ChatContext _context;

        static readonly string textBody = "Amazon SES Test (.NET)\r\n"
                                       + "This email was sent through Amazon SES "
                                       + "using the AWS SDK for .NET.";
        // The HTML body of the email.
        static readonly string htmlBody = @"<html>
<head></head>
<body>
  <h1>Amazon SES Test (AWS SDK for .NET)</h1>
  <p>This email was sent with
    <a href='https://aws.amazon.com/ses/'>Amazon SES</a> using the
    <a href='https://aws.amazon.com/sdk-for-net/'>
      AWS SDK for .NET</a>.</p>
</body>
</html>";


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
            var user = await _context.Appusers.FindAsync(Email);
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
        public async Task<IActionResult> CreateAsync(String email, String password)
        {
            using (var client = new AmazonSimpleEmailServiceClient(RegionEndpoint.USEast1))
            {
                var sendRequest = new SendEmailRequest
                {
                    Source = senderAddress,
                    Destination = new Destination
                    {
                        ToAddresses =
                        new List<string> { email }
                    },
                    Message = new Message
                    {
                        Subject = new Content(subject),
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Charset = "UTF-8",
                                Data = htmlBody
                            },
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = textBody
                            }
                        }
                    },
                    
                };
                try
                {
                    
                    var response = client.SendEmailAsync(sendRequest);
                    ViewBag.Message = String.Format("Send Email successfully");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = String.Format("Send Email fails: " + ex.Message);
                   
                }
            }
            Login login = new Login { Email = email,  PasswordHash = PBKDF2.Hash(password) };
            _context.Logins.Add(login);
            AppUser user = new AppUser { Email = login.Email };
            _context.Appusers.Add(user);
            await _context.SaveChangesAsync();
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
