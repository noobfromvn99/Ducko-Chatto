using System;
using System.ComponentModel.DataAnnotations;

namespace RandomChat.Models
{
    public class Login
    {
        [Required, StringLength(50)]
        [Key]
        public string Email { get; set; }

        public virtual AppUser AppUser { get; set; }

        [Required, StringLength(64)]
        public string PasswordHash { get; set; }


        public Boolean Activate { get; set; }

        [StringLength(6)]
        public string Code { get; set; }

        public void Verify()
        {
            Activate = true;
        }
    }
}
