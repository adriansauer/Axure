using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * CreditNote class
 * Created june 25, 2020 by Victor Ciceia.
 * Credit note when a return occurs.
 */
namespace Axure.Models.Module_Purchase
{
    public class CreditNote
    {
        //Unique identifier.
        public int Id { get; set; }

        //Return order identifier.
        [Required]
        public int ReturnOrderId { get; set; }
        [ForeignKey("ReturnOrderId")]
        public ReturnOrder ReturnOrder { get; set; }

        //Creation date.
        [Required]
        public DateTime Date { get; set; }

        //Order number.
        [Required]
        public int Number { get; set; }

        //Order amount.
        [Required]
        public int Amount { get; set; }
    }
}