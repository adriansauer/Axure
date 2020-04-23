using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * PcComponent class
 * Created march 20, 2020 by Victor Ciceia.
 */
namespace Axure.Models.Module_Stock.Models
{
    public class PcComponent
    {
        //Component that forms the product.
        public int ProductComponentId { get; set; }

        //Component quantity.
        public int Quantity { get; set; }
    }
}
