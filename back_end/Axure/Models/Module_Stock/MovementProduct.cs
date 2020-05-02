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
    public class MovementProduct
    {
        //Id
        public int Id { get; set; }

        //Fecha
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int TotalCost { get; set; }

        //FK del encargado
        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee employee { get; set; }

        //Deposito de salida o deposito destino
        [Required]
        public int DepositId { get; set; }
        [ForeignKey("DepositId")]
        public Deposit deposit { get; set; }

        //FK Entrada o Salida
        [Required]//cambiar nombre movent
        public int MovementMotiveId { get; set; }
        [ForeignKey("MovementMotiveId")]
        public MovementMotive MovementMotive { get; set; }
    }
}