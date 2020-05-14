using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RandomChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomChat.Data
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ChatContext(serviceProvider.GetRequiredService<DbContextOptions<ChatContext>>());
            if (context.Appusers.Any())
                return; // DB has already been seeded.
            context.Appusers.AddRange(
                new AppUser
                {
                    UserID = 2100,
                    Gender = "Male"
                }
            );
            context.Logins.AddRange(
                new Login
                {
                    Email = "test@test.com",
                    UsrID   = 2100,
                    PasswordHash = "YBNbEL4Lk8yMEWxiKkGBeoILHTU7WZ9n8jJSy8TNx0DAzNEFVsIVNRktiQV+I8d2"
                }
            );

            context.SaveChanges();
        }
     }
}
