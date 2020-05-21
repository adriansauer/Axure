using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Sale
{
    public class OrderSaleDetailDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Product.
        public ProductOrderSaleDTO Product { get; set; }

        public int ProductId { get; set; }

        public int OrderSaleId { get; set; }

        //Quantity to sell.
        public int Quantity { get; set; }

        //Pending amount to invoice.
        public int QuantityPending { get; set; }
    }
}