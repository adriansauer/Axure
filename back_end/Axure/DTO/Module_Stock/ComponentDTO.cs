using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class ComponentDTO
    {
        //
        public int Id { get; set; }
        //
        public ProductDTO Product { get; set; }
        //
        public ProductDTO ProductComponent { get; set; }
        //
        public int Quantity { get; set; }
    }
}