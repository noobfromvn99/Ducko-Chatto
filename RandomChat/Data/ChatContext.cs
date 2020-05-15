using Microsoft.EntityFrameworkCore;
using RandomChat.Models;

namespace RandomChat.Data
{
    public class ChatContext : DbContext
    {
        public ChatContext(DbContextOptions<ChatContext> options) : base(options)
        { }

        public DbSet<AppUser> Appusers { get; set; }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Login> Logins { get; set; }


        protected override void OnModelCreating(ModelBuilder builder) //validation
        {
            base.OnModelCreating(builder);
            builder.Entity<Login>().HasCheckConstraint("CH_Login_PasswordHash", "len(PasswordHash) = 64");

            builder.Entity<Login>().
                HasOne(e => e.AppUser);
        }
    }
}
