﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaParAPI.Models
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Siret { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
