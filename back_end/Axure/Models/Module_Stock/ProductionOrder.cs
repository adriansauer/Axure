using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * ProductionOrder class
 * Created March 1, 2020 by Victor Ciceia.
 * Product production order.
 */
namespace Axure.Models.Module_Stock
{
    public class ProductionOrder
    {
        //Unique identifier.
        public int Id { get; set; }

        //Production order status.
        [Required]
        public int ProductionStateId { get; set; }
        [ForeignKey("ProductionStateId")]
        public ProductionState ProductionState { get; set; }

        //Employee responsible for the production order.
        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        //Order creation date.
        [Required]
        public DateTime Date { get; set; }

        //Observations.
        [StringLength(200)]
        public string Observation { get; set; }

        //Used to remove ilde.
        [Required]
        public bool Deleted { get; set; }
    }
}