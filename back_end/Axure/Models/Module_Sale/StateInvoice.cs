using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * StateInvoice class
 * Created May 13, 2020 by Victor Ciceia.
 * State invoices.
 */
namespace Axure.Models.Module_Sale
{
    public class StateInvoice
    {
        //Unique identifier.
        public int Id { get; set; }

        //State description.
        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        //Used to remove ilde.
        [Required]
        public bool Deleted { get; set; }
    }
}