using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ProductionOrderReportDTO class
 * Created april 22, 2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Stock
{
    public class ProductionOrderReportDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Production order status.
        public ProductionState ProductionState { get; set; }

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