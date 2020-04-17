using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class ProductionOrderDetailDTO
    {
        //
        public int Id { get; set; }
        //
        public int IdProductComponent { get; set; }
        //
        public int IdProductionOrder { get; set; }
        //
        public int Quantity { get; set; }
    }
}