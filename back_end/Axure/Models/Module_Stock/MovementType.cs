using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * Creado por Enzo Ramirez
 * 09/04/2020
 */

namespace Axure.Models.Module_Stock
{
    public class MovementType
    {
        //Id
        public int Id { get; set; }

        //Abreviatura
        [Required]
        [StringLength(20)]
        public String Abbreviation { get; set; }

        //Descripcion
        [Required]
        [StringLength(200)]
        public String Description { get; set; }
    }
}