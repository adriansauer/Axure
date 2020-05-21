using Axure.Models.Module_Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Sale
{
    public class OrderSaleDTO
    {
        //Unique indentifier.
        public int Id { get; set; }

        //Client who placed the order.
        public int ClientId { get; set; }

        //Order state.
        //public StateOrderSale StateOrderSale { get; set; }
        public int StateOrderSaleId { get; set; }

        //Employee responsible for the order sale.
        public int EmployeeId { get; set; }

        //Order number.
        public string OrderNumber { get; set; }

        //Order creation date.
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public bool Deleted { get; set; }
    }
}