using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

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

    }
}
