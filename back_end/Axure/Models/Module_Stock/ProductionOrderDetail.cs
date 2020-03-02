using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock
{
    public class ProductionOrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int IdProduction { get; set; }
        [ForeignKey("IdProduction")]
        public ProductionState ProductionState { get; set; }
        [Required]
        public int IdProductComponent { get; set; }
        [ForeignKey("IdProductComponent")]
        public Product Product { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}