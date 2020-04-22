using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * StockDTO class
 * Created march 10, 2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Stock
{
    public class StockDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Deposit where the product is.
        public int DepositId { get; set; }

        //Product.
        public int ProductId { get; set; }

        //Product quantity.
        public int Quantity { get; set; }
    }
}