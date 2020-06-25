using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Sale
{
    public class InvoiceDTO
    {

        //Unique identifier.
        public int Id { get; set; }

        //Sale order number.
        public string OrderNumber { get; set; }

        //Invoice sale condition. 
        public string SaleCondition { get; set; }

        //Invoice status 
        public string Status { get; set; }

        //Invoice number 
        public string InvoiceNumber { get; set; }

        //Client name.
        public string ClientName { get; set; }

        //Client RUC number.
        public string ClientRUC { get; set; }

        //Client address.
        public string ClientAddress { get; set; }

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