using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandomChat.Models
{
    public class Verification
    {
        [Required, StringLength(50)]
        [Key]
        public string Email { get; set; }

        [StringLength(6)]
        public string Code { get; set; }

    }
}
