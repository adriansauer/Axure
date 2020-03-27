using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock.Models
{
    public class Pc
    {
        //Nombre del producto.
        [Required]
        [StringLength(200)]
        public string NameP { get; set; }
        //FK de lo que se espera hacer con el producto, Ej.: materia prima, venta, etc.
        [Required]
        public int IdProductType { get; set; }
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
        //Lista de componentes.
        [Required]
        public List<PcComponent> listaComponentes { get; set; }
    }
}