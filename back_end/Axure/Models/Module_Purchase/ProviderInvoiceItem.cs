using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * ProviderInvoiceItem class
 * Created June 25, 2020 by Victor Ciceia.
 * Provider invoice details.
 */
namespace Axure.Models.Module_Purchase
{
    public class ProviderInvoiceItem
    {
        //Unique identifier.
        public int Id { get; set; }

        //Provider invoice identifier.
        [Required]
        public int ProviderInvoiceId { get; set; }
        [ForeignKey("ProviderInvoiceId")]
        public ProviderInvoice ProviderInvoice { get; set; }

        //Product identifier.
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //Product name.
        [Required]
        [StringLength(100)]
        public string ProductName { get; set; }

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
        public int TaxQuantity { get; set; }

        //Total amount IVA.
        [Required]
        public int TaxTotal { get; set; }

        //Returnd quantity
        [Required]
        public int ReturndQuantity { get; set; }
    }
}