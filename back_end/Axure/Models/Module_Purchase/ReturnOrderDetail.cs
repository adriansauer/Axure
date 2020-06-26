using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * ReturnOrderDetail class
 * Created june 25, 2020 by Victor Ciceia.
 * Details of the return order.
 */
namespace Axure.Models.Module_Purchase
{
    public class ReturnOrderDetail
    {
        //Identifier unique.
        public int Id { get; set; }

        //Order return identifier.
        [Required]
        public int ReturnOrderId { get; set; }
        [ForeignKey("ReturnOrderId")]
        public ReturnOrder ReturnOrder { get; set; }

        //Return product.
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //Return product quantity.
        [Required]
        public int Quantity { get; set; }
    }
}