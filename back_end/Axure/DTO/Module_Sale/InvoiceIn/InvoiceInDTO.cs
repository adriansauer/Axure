using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Sale.InvoiceIn
{
    public class InvoiceInDTO
    {
        //Orden sale.
        public int OrderSaleId { get; set; }

        //Employee responsible for the sale.
        public int EmployeeId { get; set; }

        //Client identifier.
        public int ClientId { get; set; }

        //Invoice sale condition. 
        public string SaleCondition { get; set; }

        //Invoice status 
        public string Status { get; set; }

        //Invoice number 
        public string InvoiceNumber { get; set; }

        //Order creation date.
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public List<ItemInDTO> ListItems { get; set; }

    }
}