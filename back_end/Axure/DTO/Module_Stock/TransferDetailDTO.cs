using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class TransferDetailDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Transferred product.
        public int ProductId { get; set; }

        //Transfer header.
        public int TransferId { get; set; }

        //Quantity of product transferred.
        public int Quantity { get; set; }

        //Used to remove ilde.
        public bool Deleted { get; set; }

    }
}