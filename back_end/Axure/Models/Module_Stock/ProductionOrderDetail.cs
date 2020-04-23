using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * ProductionOrderDetail class
 * Created march 1, 2020 by Victor Ciceia.
 * Details of a production order.
 */
namespace Axure.Models.Module_Stock
{
    public class ProductionOrderDetail
    {
        //Unique identifier.
        public int Id { get; set; }

        //Production order.
        [Required]
        public int ProductionOrderId { get; set; }
        [ForeignKey("ProductionOrderId")]
        public ProductionOrder ProductionOrder { get; set; }

        //Product to be produced
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //Quantity to be produced.
        [Required]
        public int Quantity { get; set; }

        //Used to remove ilde.
        [Required]
        public bool Deleted { get; set; }
    }
}