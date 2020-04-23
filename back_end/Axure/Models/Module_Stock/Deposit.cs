using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * Deposit class
 * Created March 1, 2020 by Victor Ciceia.
 * Company deposits.
 */
namespace Axure.Models.Module_Stock
{
    public class Deposit
    {
        //Unique identifier.
        public int Id { get; set; }

        //Product name.
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}