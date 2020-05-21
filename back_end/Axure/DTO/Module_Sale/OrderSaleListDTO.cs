using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Sale
{
    public class OrderSaleListDTO
    {
        public int Id { get; set; }

        //Client who placed the order.
        public int ClientId { get; set; }

        //Order state.
        public int StateOrderSaleId { get; set; }

        //Employee responsible for the order sale.
        public int EmployeeId { get; set; }

        [StringLength(20)]
        public string OrderNumber { get; set; }

        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public bool Deleted { get; set; }


        public List<OrderSaleDetailDTO> ListDetails { get; set; }
    }
}