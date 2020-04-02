using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class StockDTO
    {
        //Id
        public int Id { get; set; }
        //
        [Required]
        public int IdDeposit { get; set; }
        //
        [Required]
        public int IdProduct { get; set; }
        //
        [Required]
        public int Quantity { get; set; }
    }
}