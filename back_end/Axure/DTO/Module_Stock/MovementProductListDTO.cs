using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class MovementProductListDTO
    {

        //Id
        public int Id { get; set; }

        //Fecha
        //Order creation date.
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        //Costo total
        public int TotalCost { get; set; }

        //FK del encargado
        public int EmployeeId { get; set; }

        //Deposito de salida o deposito destino
        public int DepositId { get; set; }

        //FK Entrada o Salida
        public int MovementTypeId { get; set; }

        //Observacion
        [StringLength(200)]
        public String Observation { get; set; }

        //Lista de detalles
        public List<MovementProductDetailDTO> ListDetails { get; set; }
    }
}