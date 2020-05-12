using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class TransferDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Deposit of origin.
        public int DepositOriginId { get; set; }

        //Deposit of destination.
        public int DepositDestinationId { get; set; }

        //Transfer date.
        public DateTime Date { get; set; }

        //Observation.
        [StringLength(200)]
        public string Observation { get; set; }

        public int Number { get; set; }

        //Used to remove ilde.
        public bool Deleted { get; set; }
    }
}