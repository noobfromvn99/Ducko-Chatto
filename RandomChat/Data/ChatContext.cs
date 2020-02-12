using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder builder) //validation
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>().HasCheckConstraint("CH_Appuser_UserID", "len(UserID) = 8");
        }
    }
}
