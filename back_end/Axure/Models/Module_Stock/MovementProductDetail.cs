using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * Creado por Enzo Ramirez
 * 09/04/2020
 */

namespace Axure.Models.Module_Stock
{
    public class MovementProductDetail
    {
        //Id
        public int Id { get; set; }

        //FK producto 
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product product { get; set; }

        //FK Cabecera de Entrada Salida 
        [Required]
        public int MovementProductId { get; set; }
        [ForeignKey("MovementProductId")]
        public MovementProductionType movementProduct { get; set; }

        //Cantidad de productos
        [Required]
        public int Quantity { get; set; }

        //Costo total
        public int TotalCost { get; set; }

        //costo unitario
        public int Cost { get; set; }

        //Observacion
        [StringLength(200)]
        public String Observation { get; set; }
    }
}