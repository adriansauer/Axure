using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Sale.InvoicePreCreation
{
    public class InvoiceOutPreCreationDTO
    {
        //Orden sale number.
        public string OrderSaleNumber { get; set; }

        //Employee responsible for the sale.
        public EmployeeDTO EmployeeDTO { get; set; }

        //Client .
        public ClientDTO ClientDTO { get; set; }

        //Invoice sale condition. 
        public string SaleCondition { get; set; }

        //Invoice number 
        public string InvoiceNumber { get; set; }

        //Validation code.
        public int ValidationCode { get; set; }

        //Order creation date.
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        //Total amount with IVA.
        public int Total { get; set; }

        //Invoice tax total.
        public int TaxTotal { get; set; }

        public List<IncoiceItemPreCreationDTO> ListItems { get; set; }
    }
}