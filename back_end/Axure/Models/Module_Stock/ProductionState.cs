using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock
{
    public class ProductionState
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string PState { get; set; }
    }
}