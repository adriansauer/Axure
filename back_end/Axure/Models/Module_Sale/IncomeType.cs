using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * IncomeType class
 * Created May 13, 2020 by Victor Ciceia.
 * Types of payment for example cash, check, etc.
 */
namespace Axure.Models.Module_Sale
{
    public class IncomeType
    {
        //Unique identifier.
        public int Id { get; set; }

        //Payment type description.
        [Required]
        [StringLength(100)]
        public string Description { get; set; }
    }
}