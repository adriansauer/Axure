using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class MovementProductDTO
    {
        //Id
        public int Id { get; set; }

        //Fecha
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        //Costo total
        public int TotalCost { get; set; }

        //FK del encargado
        public int EmployeeId { get; set; }

        //Deposito de salida o deposito destino
        public int DepositId { get; set; }

        //Observacion
        [StringLength(200)]
        public String Observation { get; set; }

        //FK Entrada o Salida
        public int MovementTypeId { get; set; }

    }
}