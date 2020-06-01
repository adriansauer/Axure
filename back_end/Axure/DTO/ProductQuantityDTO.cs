using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO
{
    public class ProductQuantityDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Product to be produced
        public int ProductId { get; set; }

        //Quantity to be produced.
        public int Quantity { get; set; }
    }
}