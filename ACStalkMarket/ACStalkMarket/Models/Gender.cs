﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ACStalkMarket.Models
{
    public class Gender
    {
        public short Id { get; set; }

        [Required]
        [StringLength(50)]
        public string GenderName { get; set; }

        public static readonly byte Default = 3;
    }
}