using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ProductCategoryDTO class
 * Created June 25, 2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Stock
{
    public class ProductCategoryDTO
    {
        //Unique identifier
        public int Id { get; set; }

        //Category description.
        public string Description { get; set; }
    }
}