﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Person
    {
        [Required]
        [EmailAddress]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }


    }
}