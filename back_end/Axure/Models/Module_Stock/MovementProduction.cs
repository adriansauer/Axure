using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * MovementProduction class
 * Created april 20, 2020 by Victor Ciceia.
 * Product movements according to production order.
 */
namespace Axure.Models.Module_Stock
{
    public class MovementProduction
    {
        //Unique identifier.
        public int Id { get; set; }

        //Employee in charge of the movement.
        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        //Movement type.
        [Required]
        public int MovementProductionTypeId { get; set; }
        [ForeignKey("MovementProductionTypeId")]
        public MovementProductionType MovementProductionType { get; set; }
        
        //Date the movement is made.
        [Required]
        public DateTime Date { get; set; }

        //Used to remove idle.
        [Required]
        public bool Deleted { get; set; }
    }
}