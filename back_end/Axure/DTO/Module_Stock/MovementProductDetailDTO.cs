using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class MovementProductDetailDTO
    {
        //Id
        public int Id { get; set; }

        //FK producto
        [Required]
        public int ProductId { get; set; }

        //FK Cabecera de Entrada Salida 
        [Required]
        public int MovementProductId { get; set; }

        //Cantidad de productos
        [Required]
        public int Quantity { get; set; }

        //Costo total
        public int TotalCost { get; set; }

        //costo unitario
        public int Cost { get; set; }

        //Observacion
        [StringLength(50)]
        public String Observation { get; set; }
    }
}