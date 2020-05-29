using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * ReceiptDetail class
 * Create Mat 13, 2020 by Victor Ciceia.
 * Details of a receipt.
 */
namespace Axure.Models.Module_Sale
{
    public class ReceiptDetail
    {
        //Unique identifier.
        public int Id { get; set; }

        //Receipt.
        [Required]
        public int ReceiptId { get; set; }
        [ForeignKey("ReceiptId")]
        public Receipt Receipt { get; set; }

        //Fee being paid.
        [Required]
        public int FeeId { get; set; }
        [ForeignKey("FeeId")]
        public Fee Fee { get; set; }

        //Invoice to which the payment belongs.
        [Required]
        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }

        //Amount of the fee.
        [Required]
        public int Amount { get; set; }
    }
}