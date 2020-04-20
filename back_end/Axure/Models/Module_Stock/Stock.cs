using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * Stock class
 * Created march 1, 2020 by Victor Ciceia.
 * Existence of a product in a deposit.
 */
namespace Axure.Models.Module_Stock
{
    public class Stock
    {
        //Unique identifier.
        public int Id { get; set; }

        //Deposit where the product is.
        [Required]
        public int IdDeposit { get; set; }
        [ForeignKey("IdDeposit")]
        public Deposit Deposit { get; set; }

        //Product.
        [Required]
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }

        //Product quantity.
        [Required]
        public int Quantity { get; set; }

        //Used to remove ilde.
        [Required]
        public bool Deleted { get; set; }
    }
}