using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 *Clase Product
 * Creado el 1 de marzo de 2020 por Victor Ciceia.
 * Producto que posee la empresa.
 */
namespace Axure.Models.Module_Stock
{
    public class Product
    {
        //Id.
        public int Id { get; set; }
        //FK de lo que se espera hacer con el producto, Ej.: materia prima, venta, etc.
        [Required]
        public int IdProductType { get; set; }
        [ForeignKey("IdProductType")]
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
        //Si es que el producto esta eliminado.
        [Required]
        public bool Delete { get; set; }
    }
}