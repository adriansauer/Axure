﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * Product class
 * Created march 1, 2020 by Victor Ciceia.
 * Company products.
 */
namespace Axure.Models.Module_Stock
{
    public class Product
    {
        //Unique identifier.
        public int Id { get; set; }

        //The type of use that the company gives to the product.
        [Required]
        public int ProductTypeId { get; set; }
        [ForeignKey("ProductTypeId")]
        public ProductType ProductType { get; set; }

        //IVA porcentage of a product.
        [Required]
        public int TaxId { get; set; }
        [ForeignKey("TaxId")]
        public Tax Tax { get; set; }

        //Product categorie.
        [Required]
        public int ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }

        //Product name.
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        //Product description.
        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        //Product cost.
        [Required]
        public int Cost { get; set; }

        //Product price.
        [Required]
        public int Price { get; set; }

        //Minimum quantity of the product.
        [Required]
        public int QuantityMin { get; set; }

        //Product barcode.
        [StringLength(20)]
        public string Barcode { get; set; }

        //Used to remove ilde.
        [Required]
        public bool Deleted { get; set; }
    }
}