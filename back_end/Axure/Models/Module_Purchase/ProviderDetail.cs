using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * ProviderDetail class
 * Created June 25, 2020 by Victor Ciceia.
 * Provider details.
 */
namespace Axure.Models.Module_Purchase
{
    public class ProviderDetail
    {
        //Unique identifier.
        public int Id { get; set; }

        //Provider identifier.
        [Required]
        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public Provider Provider { get; set; }

        //Product category identifier.
        [Required]
        public int ProductCategoryId { get; set; }
        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }
    }
}