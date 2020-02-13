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
        [Required, StringLength(8)]
        [Display(Name = "Login ID")]
        public string LoginID { get; set; }

        [Required]
        [ForeignKey("AppUser")]
        public int UsrID { get; set; }
        public virtual AppUser AppUser { get; set; }

        [Required, StringLength(64)]
        public string PasswordHash { get; set; }
    }
}
