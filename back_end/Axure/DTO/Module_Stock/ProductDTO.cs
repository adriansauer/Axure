using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class ProductDTO
    {
        //Nombre del producto.
        [Required]
        [StringLength(200)]
        public string NameP { get; set; }
        //Descripcion del producto.
        [Required]
        [StringLength(200)]
        public string DescriprionP { get; set; }
        //El costo del producto.
        [Required]
        public int Cost { get; set; }
        //Cantidad minima que se podra tener del producto.
        [Required]
        public int QuantityMin { get; set; }
        //Codigo de barra del producto.
        [StringLength(15)]
        public string Barcode { get; set; }
    }
}