using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * ProductionOrderDTO class
 * Created april 20,2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Stock
{
    public class ProductionOrderDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Production order status.
        public int ProductionStateId { get; set; }      

        //Employee responsible for the production order.
        public int EmployeeId { get; set; }

        //Order creation date.
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        //Observations.
        public string Observation { get; set; }
       
        public List<ProductQuantityDTO> ListDetails { get; set; }
    }
}