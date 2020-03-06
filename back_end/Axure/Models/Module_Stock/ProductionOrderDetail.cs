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
        //
        public int Id { get; set; }
        //
        [Required]
        public int IdProductComponent { get; set; }
        [ForeignKey("IdProductComponent")]
        public ProductComponent ProductComponent { get; set; }
        //
        [Required]
        public int IdProductionOrder { get; set; }
        [ForeignKey("IdProductionOrder")]
        public ProductionOrder ProductionOrder { get; set; }
        //
        [Required]
        public int Quantity { get; set; }
    }
}