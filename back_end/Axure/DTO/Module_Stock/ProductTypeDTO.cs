using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ProductType class
 * Created march 1, 2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Stock
{
    public class ProductTypeDTO
    {
        //Unique identifier.
        public int Id { get; set; }
        //Product type.
        public string Type { get; set; }
    }
}