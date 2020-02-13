﻿using Microsoft.EntityFrameworkCore;
using RandomChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomChat.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        { }

        public DbSet<AppUser> Appusers { get; set; }
        public DbSet<Message> Messages{ get; set; }
        public DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) //validation
        {
            base.OnModelCreating(builder);
            builder.Entity<Login>().HasCheckConstraint("CH_Login_LoginID", "len(LoginID) = 8").
                HasCheckConstraint("CH_Login_PasswordHash", "len(PasswordHash) = 64");

            builder.Entity<Message>().
                HasOne(e => e.AppUser).WithMany(e => e.Messages).HasForeignKey(e => e.UsrID);

            builder.Entity<Login>().
                HasOne(e => e.AppUser).WithOne(e => e.Login);
        }
    }
}
