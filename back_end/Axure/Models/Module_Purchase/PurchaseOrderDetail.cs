using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * PurchaseOrderDetail class
 * Created june 25, 2020 by Victor Ciceia.
 * Details of the purchase order.
 */
namespace Axure.Models.Module_Purchase
{
    public class PurchaseOrderDetail
    {
        //Unique identifier.
        public int Id { get; set; }

        //Purchase order identifier.
        [Required]
        public int PurchaseOrderId { get; set; }
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }

        //Product identifier.
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //Product quatity.
        [Required]
        public int Quantity { get; set; }

        //Quantity pending the product.
        [Required]
        public int QuantityPending { get; set; }

        //Price product.
        [Required]
        public int Price { get; set; }
    }
}