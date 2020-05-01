using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * Transfer class
 * Created march 1, 2020 by Victor Ciceia.
 * Transfer of products from one deposit to another.
 */
namespace Axure.Models.Module_Stock
{
    public class Transfer
    {
        //Unique identifier.
        public int Id { get; set; }

        //Deposit of origin.
        [Required]
        public int DepositOriginId { get; set; }
        [ForeignKey("DepositOriginId")]
        public Deposit DepositOrgin { get; set; }

        //Deposit of destination.
        [Required]
        public int DepositDestinationId { get; set; }
        [ForeignKey("DepositDestinationId")]
        public Deposit DepositDestination { get; set; }

        //Transfer date.
        [Required]
        public DateTime Date { get; set; }

        //Observation.
        [StringLength(200)]
        public string Observation { get; set; }

        //[Required]
        public int Number { get; set; }

        //Used to remove ilde.
        [Required]
        public bool Deleted { get; set; }
    }
}