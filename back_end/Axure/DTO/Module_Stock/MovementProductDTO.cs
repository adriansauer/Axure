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

        //Numero de Entrada Salida
        public int Number { get; set; }

        //Fecha
        public DateTime Date { get; set; }

        //Costo total
        public int TotalCost { get; set; }

        //FK del encargado
        public int EmployeeId { get; set; }

        //Deposito de salida o deposito destino
        public int DepositId { get; set; }

        //FK Entrada o Salida
        public int MovementMotiveId { get; set; }
    }
}