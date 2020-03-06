﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock
{
    public class Deposit
    {
        //
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string NameD { get; set; }
    }
}