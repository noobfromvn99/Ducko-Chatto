using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RandomChat.Models
{
  
    public class AppUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int UserID {get;set;}
        
        public string Gender { get; set; }

        [Required]
        [ForeignKey("Login")]
        public string Email { get; set; }
        public virtual Login Login { get; set; }
    }
}
