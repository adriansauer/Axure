using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * PaymentTerm class
 * Created May 13, 2020 by Victor Ciceia.
 * Ways in which the invoice will be paid, example credit or cash.
 */
namespace Axure.Models.Module_Sale
{
    public class PaymentTerm
    {
        //Unique identifier.
        public int Id { get; set; }

        //Description of the payment method of the invoice.
        [Required]
        [StringLength(20)]
        public string Description { get; set; }
    }
}