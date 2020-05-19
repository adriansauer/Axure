using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * Receipt class
 * Created May 13, 2020 by Victor Ciceia.
 * Receipt of money for paying an invoice.
 */
namespace Axure.Models.Module_Sale
{
    public class Receipt
    {
        //Unique identifier.
        public int Id { get; set; }

        //Client identifier.
        [Required]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        //Client Name.
        [Required]
        [StringLength(100)]
        public string ClientName { get; set; }

        //Total amount received.
        [Required]
        public int Amount { get; set; }

        //Creation date.
        [Required]
        public DateTime Date { get; set; }
    }
}