using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Sale
{
    public class InvoiceItemsDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Product name.
        public string ProductName { get; set; }

        //Product unit price.
        public int PriceUnit { get; set; }

        //Product quantity.
        public int Quantity { get; set; }

        //Total amount with tax.
        public int Total { get; set; }

        //IVA percentage.
        public int TaxQuantity { get; set; }

        //Total amount IVA.
        public int TaxTotal { get; set; }
    }
}