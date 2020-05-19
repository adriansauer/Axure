using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * IncomeDeadline class
 * Created May 13, 2020 by Victor Ciceia.
 * Payment terms of a credit invoice.
 */
namespace Axure.Models.Module_Sale
{
    public class IncomeDeadline
    {
        //Unique identifier.
        public int Id { get; set; }

        //Number of months, example 30, 60 90 months.
        [Required]
        public int MonthsQuantity { get; set; }

        //Term description
        [Required]
        public string Description { get; set; }
    }
}