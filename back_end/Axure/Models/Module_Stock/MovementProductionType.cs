using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * MovementProductionType class
 * Created april 20, 2020 by Victor Ciceia.
 * Types of product movements according to production order.
 */
namespace Axure.Models.Module_Stock
{
    public class MovementProductionType
    {
        //Unique identifier.
        public int Id { get; set; }

        //Movement type.
        [Required]
        [StringLength(20)]
        public string Type { get; set; }
    }
}
