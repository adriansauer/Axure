using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * MovementProductionDetail class
 * Created April 20, 2020 by Victor Ciceia.
 * Detail od the movement of products for production.
 */
namespace Axure.Models.Module_Stock
{
    public class MovementProductionDetail
    {
        //Unique identifier.
        public int Id { get; set; }

        //Production movement header.
        [Required]
        public int MovementProductionId { get; set; }
        [ForeignKey("MovementProductionId")]
        public MovementProduction MovementProduction { get; set; }

        //Production order containing the products to be produced.       
        [Required]
        public int ProductionOrderId { get; set; }
        [ForeignKey("ProductionOrderId")]
        public ProductionOrder ProductionOrder { get; set; }

        //Used to remove idle.
        [Required]
        public bool Deleted { get; set; }
    }
}
