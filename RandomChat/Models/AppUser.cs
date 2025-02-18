﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RandomChat.Models
{

    public class AppUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int? UserID { get; set; }

        public string Location { get; set; }

        [Required]
        [ForeignKey("Login")]
        public string Email { get; set; }

        public virtual List<Topic> Topics { get; set; }
        public virtual Login Login { get; set; }
    }
}
