using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock
{
    public class ComprobantePurchaseDetail
    {
        public int Id { get; set; }
        public int IdComprobantePurchase { get; set; }
        [ForeignKey("IdComprobantePurchase")]
        public Transfer Transfer { get; set; }
        [Required]
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}