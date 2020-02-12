﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandomChat.Models
{
    public enum Gender
    {
        Male,
        FeMale,
        Blur
    }
    public enum ageStage
    {
        Low,
        Mediumn,
        High
    }

    public class AppUser
    {
        [Required]
        public int UsrID {get;set;}
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public ageStage AgeStage { get; set; }

        public virtual List<Message> Messages { get; set; }
    }
}
