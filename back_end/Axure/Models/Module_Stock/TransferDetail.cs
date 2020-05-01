using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * TransferDetail class
 * Created march 1, 2020 by Victor Ciceia.
 * Details of the transfer of products from deposit to deposit.
 */
namespace Axure.Models.Module_Stock
{
    public class TransferDetail
    {
        //Unique identifier.
        public int Id { get; set; }

        //Transferred product.
        [Required]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        //Transfer header.
        [Required]
        public int TransferId { get; set; }
        [ForeignKey("TransferId")]
        public Transfer Transfer { get; set; }

        //Quantity of product transferred.
        [Required]
        public int Quantity { get; set; }

        //Used to remove ilde.
        [Required]
        public bool Deleted { get; set; }

        //[Required]
        public int Number { get; set; }
    }
}