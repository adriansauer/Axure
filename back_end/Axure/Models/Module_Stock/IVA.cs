using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * IVA class
 * Created May 13, 2020 by Victor Ciceia.
 * Amount of tax a product has.
 */
namespace Axure.Models.Module_Stock
{
    public class IVA
    {
        //Unique identifier.
        public int Id { get; set; }

        //Percentage.
        [Required]
        public int Quantity { get; set; }

        //IVA description.
        [Required]
        [StringLength(10)]
        public string Description { get; set; }

        //Used to remove ilde.
        [Required]
        public bool Deleted { get; set; }
    }
}