using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * Income class
 * Created May 13, 2020 by Victor Ciceia.
 * Cash payment income.
 */
namespace Axure.Models.Module_Sale
{
    public class Income
    {
        //Unique identifier.
        public int Id { get; set; }

        //Type of payment.
        [Required]
        public int IncomeTypeId { get; set; }
        [ForeignKey("IncomeTypeId")]
        public IncomeType IncomeType { get; set; }

        //Invoice.
        [Required]
        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }

        //Total amount.
        [Required]
        public int Amount { get; set; }

        //Creation date.
        [Required]
        public DateTime Date { get; set; }
    }
}