using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * Pc class
 * Created march 20, 2020 by Victor Ciceia.
 */
namespace Axure.Models.Module_Stock.Models
{
    public class Pc
    {
        //Unique identifier.
        public int Id { get; set; }

        //Product name.
        public string Name { get; set; }

        //The type of use that the company gives to the product.
        public int ProductTypeId { get; set; }

        //Product description.
        public string Description { get; set; }
        public int ProductCategoryId { get; set; }
        //Product cost.
        public int Cost { get; set; }

        //IVA percentage of a product.
        public int TaxId { get; set; }

        //Minimum quantity of the product.
        public int QuantityMin { get; set; }
        
        //Product barcode.
        public string Barcode { get; set; }
        
        //List component.
        public List<PcComponent> ListComponents { get; set; }
    }
}