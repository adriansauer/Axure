using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Sale.InvoicePreCreation
{
    public class InvoiceInPreCreationDTO
    {
        //Orden sale.
        public int OrderSaleId { get; set; }

        //Employee responsible for the sale.
        public int EmployeeId { get; set; }

        //Invoice sale condition. 
        public string SaleCondition { get; set; }

        //Order creation date.
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public List<ProductQuantityDTO> ListItems { get; set; }
    }
}