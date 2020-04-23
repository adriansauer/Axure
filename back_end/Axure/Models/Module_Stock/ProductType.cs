using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * ProductType class
 * Created march 1, 2020 by Victor Ciceia.
 * Type of product that represents for the company such as raw material.
 */
namespace Axure.Models.Module_Stock
{
    public class ProductType
    {
        //Unique identifier.
        public int Id { get; set; }

        //Product type.
        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        //Used to remove ilde.
        [Required]
        public bool Deleted { get; set; }
    }
}