using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock.Models
{
    public class PcComponent
    {
        [Required]
        public int IdProductComponent { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
