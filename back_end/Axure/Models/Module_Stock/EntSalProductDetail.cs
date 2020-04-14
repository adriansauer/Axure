﻿using System;
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
    public class EntSalProductDetail
    {
        //Id
        public int Id { get; set; }

        //FK producto
        [Required]
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public Product product { get; set; }

        //FK Cabecera de Entrada Salida 
        [Required]
        public int IdEntSalProduct { get; set; }
        [ForeignKey("IdEntSalProduct")]
        public EntSalProduct entSalProduct { get; set; }

        //Cantidad de productos
        [Required]
        public int Quantity { get; set; }

        //Costo total
        public int TotalCost { get; set; }

        //Observacion
        [StringLength(50)]
        public String Observation { get; set; }
    }
}