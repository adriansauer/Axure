using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * TransferType class
 * Created march 1, 2020 by Victor Ciceia.
 * Type of product transfer.
 */
namespace Axure.Models.Module_Stock
{
    public class TransferType
    {
        //Unique identifier.
        public int Id { get; set; }

        //Transfer type.
        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        //Used to remove ilde.
        [Required]
        public bool Deleted { get; set; }
    }
}