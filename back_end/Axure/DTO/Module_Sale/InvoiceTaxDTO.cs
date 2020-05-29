using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Sale
{
    public class InvoiceTaxDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Product tax percentage.
        public int TaxPercentage { get; set; }

        //TaxPercentage total.
        public int Amount { get; set; }
    }
}