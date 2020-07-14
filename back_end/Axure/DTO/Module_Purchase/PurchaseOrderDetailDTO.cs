using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Purchase
{
    public class PurchaseOrderDetailDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        //Product quatity.
        public int Quantity { get; set; }

        //Quantity pending the product.
        public int QuantityPending { get; set; }

        //Price product.
        public int Price { get; set; }

    }
}