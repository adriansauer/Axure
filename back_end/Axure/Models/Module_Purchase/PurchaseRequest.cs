using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * PurchaseRequest class
 * Created March 1, 2020 by Victor Ciceia.
 * Proof of purchase of products.
 */
namespace Axure.Models.Module_Purchase
{
    public class PurchaseRequest
    {
        //Unique identifier.
        public int Id { get; set; }     

        //Date of purchase.
        [Required]
        public DateTime Date { get; set; }

        //Request number.
        [Required]
        public int Number { get; set; }

        //Used to remove idle.
        [Required]
        public bool Deleted { get; set; }
    }
}