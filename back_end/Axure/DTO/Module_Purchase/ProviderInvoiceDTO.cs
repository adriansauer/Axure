using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Purchase
{
    public class ProviderInvoiceDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Provider identifier.
        public int ProviderId { get; set; }

        //Purchase order identifier.
        public int PurchaseOrderId { get; set; }

        //Invoice status 
        public string Status { get; set; }

        //Invoice number 
        public string InvoiceNumber { get; set; }

        //Provider name.
        public string ProviderName { get; set; }

        //Provider RUC number.
        public string ProviderRUC { get; set; }

        //Provider address.
        public string ProviderAddress { get; set; }

        //Order creation date.
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        //Total amount with IVA.
        public int Total { get; set; }

        //Invoice tax total.
        public int TaxTotal { get; set; }
    }
}