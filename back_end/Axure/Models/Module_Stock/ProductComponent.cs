using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * ProductComponent class
 * Created march 1, 2020 by Victor Ciceia.
 * Components of a product (Computer).
 */
namespace Axure.Models.Module_Stock
{
    public class ProductComponent
    {
        //Unique identifier.
        public int Id { get; set; }

        //Product that is composed of the component.
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //Component that forms the product.
        [Required]
        public int ProductComponentId { get; set; }
        [ForeignKey("ProductComponentId")]
        public Product ProductComp { get; set; }

        //Component quantity.
        [Required]
        public int Quantity { get; set; }
    }
}