using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock
{
    public class ProductBrand
    {
        //Id
        public int Id { get; set; }
        //Marca del Producto
        [Required]
        [StringLength(50)]
        public string Brand { get; set; }
    }
}