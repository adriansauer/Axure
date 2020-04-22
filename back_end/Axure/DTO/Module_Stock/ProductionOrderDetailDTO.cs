using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ProductionOrderDetailDTO class
 * Created april 20,2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Stock
{
    public class ProductionOrderDetailDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Production order.
        public int ProductionOrderId { get; set; }

        //Product to be produced
        public int ProductId { get; set; }

        //Quantity to be produced.
        public int Quantity { get; set; }
    }
}