using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Purchase
{
    public class PurchaseOrderDetailsDTO : PurchaseOrderDTO
    {
        public List<PurchaseOrderDetailDTO> ListDetails { get; set; }
    }
}