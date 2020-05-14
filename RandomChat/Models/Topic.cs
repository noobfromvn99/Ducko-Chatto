using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RandomChat.Models
{
    public class Topic
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int TopicId { get; set; }

        [Required]
        public string TopicName { get; set; }

        [Required]
        [ForeignKey("AppUser")]
        public int UserId { get; set; }
        public virtual AppUser creator { get; set; }
    }
}
