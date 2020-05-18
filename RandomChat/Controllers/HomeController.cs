using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomChat.Attributes;
using RandomChat.Data;
using RandomChat.Models;
using SimpleHashing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomChat.Controllers
{
    public class HomeController : Controller
    {
        // ConfigurationSetName = configSet argument below. 

        static readonly string senderAddress = "bach.rmit.5499@gmail.com";
        static readonly string subject = "Ducko-Chatto verification";
        private readonly LocationManger LocationClient;
        private readonly ChatContext _context;

        public HomeController(ChatContext context)
        {
            LocationClient = LocationManger.GetInstance();
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
            
            //Validation
            if (login == null || !PBKDF2.Verify(login.PasswordHash, Password))
            {
                ModelState.AddModelError("LoginFailed", "Login failed, please try again.");
                return View(new Login { Email = Email });
            }
            else if (login.Activate == false)
            {
                ModelState.AddModelError("LoginFailed", "Login failed, please activate your account and try again.");
                return RedirectToAction("Verify", new { Email = Email });
            }
            var user = _context.Appusers.Where(e => e.Email == Email).Single();

            var remoteIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();
            Location location = await LocationClient.GetLocation(remoteIpAddress);

            string city = "AU"; //City of deafult for test
            if (location.city != null) 
            {
                city = location.city;
            }

            // Login customer.
            HttpContext.Session.SetInt32(nameof(AppUser.UserID), Convert.ToInt32(user.UserID));
            HttpContext.Session.SetString("city", city);
            return RedirectToAction("Index", "Chat");
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Verify()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Verify(String email, String code)
        {
            var login = await _context.Logins.FindAsync(email);
            if (login == null)
            {
                ViewBag.Message = String.Format("Verification fail! Email is not available");
                return View();
            }
            else if (login.Code != code)
            {
                ViewBag.Message = String.Format("Verification fail! Verification code is incorrect");
                return View();
            }
            else if (login.Activate == true)
            {
                ViewBag.Message = String.Format("This account already verified");
                return View();
            }
            else
            {
                ViewBag.Message = String.Format("Verification successfully");
                login.Verify();
                await _context.SaveChangesAsync(); //save changes
                return View();
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateAsync(string email, string password)
        {
            Login login = new Login { Email = email, PasswordHash = PBKDF2.Hash(password), Activate = false, Code = GenerateCode() };
            _context.Logins.Add(login);
            AppUser user = new AppUser { Email = login.Email };
            _context.Appusers.Add(user);
            try
            {
                await _context.SaveChangesAsync();
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
                                    Data = HtmlBody(login.Code)
                                },
                                Text = new Content
                                {
                                    Charset = "UTF-8",
                                    Data = TextBody(login.Code)
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

            }
            catch (Exception)
            {
                ModelState.AddModelError("Insert", "Sign up failed, email has been token.");
            }



            return View();
        }
        [AuthorizeUser]
        [Route("LogoutNow")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private string GenerateCode()
        {
            int length = 6;
            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }
        private string TextBody(string code)
        {
            string message = "Welcome to Ducko-Chatto\r\n" +
                "This email was sent with Amazon SES using the AWS SDK for .NET\r\n" +
                "Please verify with this code:\r\n" + code +
                "\r\nverify here";
            return message;
        }
        // The HTML body of the email.
        private string HtmlBody(string code)
        {
            string message = @"<html>
<head></head>
<body>
  <h1>Welcome to Ducko-Chatto</h1>
  <p>This email was sent with
    <a href='https://aws.amazon.com/ses/'>Amazon SES</a> using the
    <a href='https://aws.amazon.com/sdk-for-net/'>
      AWS SDK for .NET</a>.</p>
  <p>Please verify with this code:</p>
  <h3>" + code + @"</h3>
  <p><a href='https://aws.amazon.com/ses/'>verify here</a></p>
</body>
</html>";
            return message;
        }
    }
}
