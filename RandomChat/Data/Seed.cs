﻿using Microsoft.Extensions.DependencyInjection;
using RandomChat.Models;
using System;
using System.Linq;

namespace RandomChat.Data
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ChatContext(serviceProvider.GetRequiredService<DbContextOptions<ChatContext>>());
            if (context.Appusers.Any())
                return; // DB has already been seeded.
            context.Logins.AddRange(
               new Login
               {
                   Email = "test@test.com",
                   PasswordHash = "YBNbEL4Lk8yMEWxiKkGBeoILHTU7WZ9n8jJSy8TNx0DAzNEFVsIVNRktiQV+I8d2"
               }
           );
            context.Appusers.AddRange(
                new AppUser
                {
                    Gender = "Male",
                    Email = "test@test.com",
                }
            );


            context.SaveChanges();
        }
    }
}
