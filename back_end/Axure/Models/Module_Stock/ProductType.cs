using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 *Clase ProductType
 * Creado el 1 de marzo de 2020 por Victor Ciceia.
 * Modelo del tipo de Producto, lo que se espera hacer con el producto en la actualidad, 
 * este modelo es utilizado por la base de datos.
 * Ej.: Si es para produccion, venta, etc.
 */
namespace Axure.Models.Module_Stock
{
    public class ProductType
    {
        //Id.
        public int Id { get; set; }
        //Especificacion de lo que se espera hacer con el producto.
        [Required]
        [StringLength(50)]
        public string TypeP { get; set; }
        [Required]
        public bool Delete { get; set; }
    }
}