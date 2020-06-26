using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * ReturnOrder class
 * Created june 25, 2020 by Victor Ciceia
 * Order of return of products of provider
 */
namespace Axure.Models.Module_Purchase
{
    public class ReturnOrder
    {
        //Unique identifier.
        public int Id { get; set; }

        //Provider identifier.
        [Required]
        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public Provider Provider { get; set; }

        //Order creation date.
        [Required]
        public DateTime Date { get; set; }

        //Order number.
        [Required]
        public int Number { get; set; }
    }
}