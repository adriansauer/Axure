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
    public class MovementMotive
    {
        //
        public int Id { get; set; }
        //FK Entrada o Salida
        [Required]//cambiar nombre movent
        public int MovementTypeId { get; set; }
        [ForeignKey("MovementTypeId")]
        public MovementType MovementType { get; set; }
        //
        [Required]
        [StringLength(200)]
        public string Motive { get; set; }
    }
}