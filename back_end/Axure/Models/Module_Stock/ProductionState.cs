using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * ProductionState class
 * Created March 1, 2020 by Victor Ciceia.
 * Status of a production order.
 */
namespace Axure.Models.Module_Stock
{
    public class ProductionState
    {
        //Unique identifier.
        public int Id { get; set; }

        //Production state.
        [Required]
        [StringLength(50)]
        public string State { get; set; }

        //Used to remove ilde.
        [Required]
        public bool Delete { get; set; }
    }
}