using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class EntSalProductDTO
    {
        //Id
        public int Id { get; set; }

        //Numero de Entrada Salida
        [Required]
        public int EntSalNumber { get; set; }

        //Fecha
        [Required]
        public DateTime DateP { get; set; }

        //Costo total
        public int TotalCost { get; set; }

        //Razon de Entrada Salida
        [Required]
        [StringLength(5)]
        public String Reason { get; set; }

        //FK del encargado
        [Required]
        public int IdEmployee { get; set; }
        [ForeignKey("IdEmployee")]
        public Employee employee { get; set; }

        //Deposito de salida o deposito destino
        [Required]
        public int IdDeposit { get; set; }
        [ForeignKey("IdDeposit")]
        public Deposit deposit { get; set; }

        //FK Entrada o Salida
        [Required]
        public int IdEntSalType { get; set; }
        [ForeignKey("IdEntSalType")]
        public EntSalType entSalType { get; set; }
    }
}