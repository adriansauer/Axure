using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * OrderSaleDetail class
 * Created May 13, 2020 by Victor Ciceia.
 * Order details of sale.
 */
namespace Axure.Models.Module_Sale
{
    public class OrderSaleDetail
    {
        //Unique identifier.
        public int Id { get; set; }

        //Order sale.
        [Required]
        public int SaleOrderId { get; set; }
        [ForeignKey("SaleOrderId")]
        public OrderSale OrderSale { get; set; }

        //Product to sell.
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //Quantity to sell.
        [Required]
        public int Quantity { get; set; }

        //Pending amount to invoice.
        [Required]
        public int QuantityPending { get; set; }

        //Used to remove ilde.
        [Required]
        public bool Deleted { get; set; }
    }
}