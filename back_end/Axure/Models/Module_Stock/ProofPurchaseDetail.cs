using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * ProofPurchaseDetail class
 * Created March 1, 2020 by Victor Ciceia.
 * Contains details of proof of purchase.
 */

namespace Axure.Models.Module_Stock
{
    public class ProofPurchaseDetail
    {
        //Unique identifier.
        public int Id { get; set; }

        //Header of proof of purchase.
        [Required]
        public int ProofPurchaseId { get; set; }
        [ForeignKey("ProofPurchaseId")]
        public ProofPurchase ProofPurchase { get; set; }

        //Purchased product.
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //Product quantity
        [Required]
        public int Quantity { get; set; }

        //Used to remove idle.
        [Required]
        public bool Deleted { get; set; }
    }
}