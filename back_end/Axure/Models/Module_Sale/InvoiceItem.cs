using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * InvoiceItem class
 * Created May 13, 2020 by Victor Ciceia.
 * Invoice product.
 */
namespace Axure.Models.Module_Sale
{
    public class InvoiceItem
    {
        //Unique identifier.
        public int Id { get; set; }

        //Invoice
        [Required]
        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }

        //Product
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //Product name.
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

        //Unit purchase price of the product.
        [Required]
        public int PricePurchase { get; set; }

        //Product unit price.
        [Required]
        public int PriceUnit { get; set; }

        //Product quantity.
        [Required]
        public int Quantity { get; set; }

        //Total amount with IVA.
        [Required]
        public int Total { get; set; }

        //IVA percentage.
        [Required]
        public int IVAQuantity { get; set; }

        //Total amount IVA.
        [Required]
        public int IVATotal { get; set; }

    }
}