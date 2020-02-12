using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandomChat.Models
{
    public class Message
    {
        [Required]
        public int MessageID { get; set; }

        [Required]
        public int UsrID { get; set; }
        public virtual AppUser AppUser {get; set; }

        public string Content { get; set; }
    }
}
