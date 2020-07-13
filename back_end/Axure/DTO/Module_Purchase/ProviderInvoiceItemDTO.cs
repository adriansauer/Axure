using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Purchase
{
    public class ProviderInvoiceItemDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Provider invoice identifier.
        public int ProviderInvoiceId { get; set; }

        //Product identifier.
        public int ProductId { get; set; }

        //Product name.
        public string ProductName { get; set; }

        //Product unit price.
        public int PriceUnit { get; set; }

        //Product quantity.
        public int Quantity { get; set; }

        //Total amount with IVA.
        public int Total { get; set; }

        //IVA percentage.
        public int TaxQuantity { get; set; }

        //Total amount IVA.
        public int TaxTotal { get; set; }

        //Returnd quantity
        public int ReturndQuantity { get; set; }
    }
}