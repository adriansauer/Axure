using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ComponentDTO class
 * Created march 20, 2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Stock
{
    public class ComponentDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Product that is composed of the component.
        public int ProductId { get; set; }

        //Component that forms the product.
        public ProductDTO ProductComponent { get; set; }

        //Component quantity.
        public int Quantity { get; set; }
    }
}