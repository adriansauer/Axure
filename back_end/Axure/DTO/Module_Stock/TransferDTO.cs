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

        //Transfer creation date.
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        //Observation.
        [StringLength(200)]
        public string Observation { get; set; }

        //Used to remove ilde.
        public bool Deleted { get; set; }
    }
}