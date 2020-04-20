using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * ProofPurchase class
 * Created March 1, 2020 by Victor Ciceia.
 * Proof of purchase of products.
 */
namespace Axure.Models.Module_Stock
{
    public class ProofPurchase
    {
        //Unique identifier.
        public int Id { get; set; }     

        //Product provider.
        [Required]
        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public Provider Provider { get; set; }

        //Purchasing employee.
        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        //Date of purchase.
        [Required]
        public DateTime Date { get; set; }

        //Used to remove idle.
        [Required]
        public bool Deleted { get; set; }
    }
}