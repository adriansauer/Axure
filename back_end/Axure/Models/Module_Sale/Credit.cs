using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * Credit class
 * Created May 13, 2020 by Victor Ciceia.
 * Credits of a invoice.
 */
namespace Axure.Models.Module_Sale
{
    public class Credit
    {
        //Unique identifier.
        public int Id { get; set; }

        //Invoice.
        [Required]
        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }

        //Deadline type.
        [Required]
        public int IncomeDeadlineId { get; set; }
        [ForeignKey("IncomeDeadlineId")]
        public IncomeDeadline IncomeDeadline { get; set; }

        //Fee quantity.
        [Required]
        public int FeeQuantity { get; set; }
    }
}