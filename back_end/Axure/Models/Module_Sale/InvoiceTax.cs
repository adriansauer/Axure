using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * InvoiceTax class
 * Created May 27, 2020 by Victor Ciceia
 * Invoice taxes, example 0%, 5% and 10%.
 */ 
namespace Axure.Models.Module_Sale
{
    public class InvoiceTax
    {
        //Unique identifier.
        public int Id { get; set; }

        //Invoice.
        [Required]
        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }

        //TaxPercentage.
        [Required]
        public int TaxId { get; set; }
        [ForeignKey("TaxId")]
        public Tax Tax { get; set; }

        //Product tax percentage.
        [Required]
        public int TaxPercentage { get; set; }

        //TaxPercentage total.
        [Required]
        public int Amount { get; set; }

    }
}