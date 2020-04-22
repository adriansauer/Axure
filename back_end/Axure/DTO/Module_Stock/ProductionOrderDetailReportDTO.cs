using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ProductionOrderDetailReportDTO class
 * Created april 22,2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Stock
{
    public class ProductionOrderDetailReportDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Production order.
        public int ProductionOrderId { get; set; }

        //Product to be produced
        public ProductDTO Product { get; set; }

        //Quantity to be produced.
        public int Quantity { get; set; }
    }
}