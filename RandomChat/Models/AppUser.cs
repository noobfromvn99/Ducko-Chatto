using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandomChat.Models
{
  
    public class AppUser
    {
        [Required]
        [Key]
        public int UsrID {get;set;}
       
        [Required]
        public string Email {get;set;}

        public virtual Login Login { get; set; }
    }
}
