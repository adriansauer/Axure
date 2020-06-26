using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * PriceRequestDetail class
 * Created june 25, 2020 by Victor Ciceia.
 * Details request of price to provider.
 */
namespace Axure.Models.Module_Purchase
{
    public class PriceRequestDetail
    {
        //Unique identifier.
        public int Id { get; set; }

        //Price request identifier.
        [Required]
        public int PriceRequestId { get; set; }
        [ForeignKey("PriceRequestId")]
        public PriceRequest PriceRequest { get; set; }

        //Product identifier.
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //Product quatity.
        [Required]
        public int Quantity { get; set; }

        //Price product.
        [Required]
        public int Price { get; set; }
    }
}