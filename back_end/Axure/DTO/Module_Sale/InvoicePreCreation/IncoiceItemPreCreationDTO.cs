using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Sale.InvoicePreCreation
{
    public class IncoiceItemPreCreationDTO
    {
        //Unique identifier
        public int Id { get; set; }

        //Product name.
        public string Name { get; set; }

        //Product description.
        public string Description { get; set; }

        //Quantity of the product for sale.
        public int QuantitySale { get; set; }

        //Product unit price.
        public int UnitPrice { get; set; }

        //Product total price.
        public int Total { get; set; }

        //IVA percentage of a product.
        public int TaxPercentage { get; set; }

        //Product tax amount
        public int Tax { get; set; }

        //Product barcode.
        public string Barcode { get; set; }

        //Error code.
        public int CodeStatus { get; set; }
    }
}