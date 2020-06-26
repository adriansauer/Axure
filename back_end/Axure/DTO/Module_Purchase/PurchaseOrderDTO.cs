using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Purchase
{
    public class PurchaseOrderDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Provider identifier.
        public int ProviderId { get; set; }

        public string ProviderName { get; set; }

        //Order creation date.
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        //Order number.
        public int Number { get; set; }

        //Order status
        public string Status { get; set; }
    }
}