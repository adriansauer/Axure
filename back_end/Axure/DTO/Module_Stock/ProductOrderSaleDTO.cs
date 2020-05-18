using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ProductOrderSaleDTO class
 * Created May 18, 2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Stock
{
    public class ProductOrderSaleDTO
    {
        //Unique identifier
        public int Id { get; set; }

        //Product name.
        public string Name { get; set; }

        //Product description.
        public string Description { get; set; }

        //Product cost.
        public int Cost { get; set; }

        //IVA percentage of a product.
        public int IVA { get; set; }

        //Product barcode.
        public string Barcode { get; set; }
    }
}
