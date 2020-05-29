using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * Debt class
 * Created May 13, 2020 by Victor Ciceia.
 * Credits of a invoice.
 */
namespace Axure.Models.Module_Sale
{
    public class Debt
    {
        //Unique identifier.
        public int Id { get; set; }

        //Invoice.
        [Required]
        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }

        //Fee quantity.
        [Required]
        public int FeeQuantity { get; set; }

        //Remaining debt.
        [Required]
        public int RemainingDebt { get; set; }

        //Fee type. Is of type enum.
        [Required]
        [StringLength(20)]
        public string FeeType { get; set; }
    }
}