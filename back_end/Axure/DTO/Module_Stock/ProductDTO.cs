using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class ProductDTO
    {
        //Id.
        public int Id { get; set; }
        //El tipo de producto, Ej.: materia prima, venta, etc.
        public ProductType ProductType { get; set; }
        //Nombre del producto.
        [Required]
        [StringLength(200)]
        public string NameP { get; set; }
        //Descripcion del producto.
        [Required]
        [StringLength(200)]
        public string DescriptionP { get; set; }
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