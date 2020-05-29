using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * ProductDTO class
 * Created april 20, 2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Stock
{
    public class ProductDTO
    {
        //Unique identifier
        public int Id { get; set; }

        //The type of use that the company gives to the product.
        public ProductType ProductType { get; set; }

        //Product name.
        public string Name { get; set; }

        //Product description.
        public string Description { get; set; }
        
        //Product cost.
        public int Cost { get; set; }

        //Product price.
        public int Price { get; set; }

        //IVA percentage of a product.
        public int TaxPercentage { get; set; }

        //Minimum quantity of the product.
        public int QuantityMin { get; set; }

        //Product barcode.
        public string Barcode { get; set; }
    }
}