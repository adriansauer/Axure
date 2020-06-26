using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * ProductCategory class
 * Created june 25, 2020 by Victor Ciceia
 * Product categorie.
 */
namespace Axure.Models.Module_Stock
{
    public class ProductCategory
    {
        //Unique identifier.
        public int Id { get; set; }

        //Product name.
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}