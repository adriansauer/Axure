using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * PurchaseOrder class
 * Created june 25, 2020 by Victor Ciceia
 * Purchase order.
 */
namespace Axure.Models.Module_Purchase
{
    public class PurchaseOrder
    {
        //Unique identifier.
        public int Id { get; set; }

        //Provider identifier.
        [Required]
        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public Provider Provider { get; set; }

        //Creation date.
        [Required]
        public DateTime Date { get; set; }

        //Order number.
        [Required]
        public int Number { get; set; }

        //Order status
        [Required]
        [StringLength(20)]
        public string Status { get; set; }
    }
}