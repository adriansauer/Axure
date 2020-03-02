using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string NameP { get; set; }
        [Required]
        [StringLength(200)]
        public string DescriprionP { get; set; }
        [Required]
        public int Cost { get; set; }
        [Required]
        public int IdProductType { get; set; }
        [ForeignKey("IdProductType")]
        public ProductType ProductType { get; set; }
        [Required]
        public int QuantityMin { get; set; }
        [Required]
        [StringLength(15)]
        public string Barcode { get; set; }
    }
}