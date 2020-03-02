using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock
{
    public class TransferDetail
    {
        public int Id { get; set; }
        [Required]
        public int IdTransfer { get; set; }
        [ForeignKey("IdTransfer")]
        public Transfer Transfer { get; set; }
        [Required]
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}