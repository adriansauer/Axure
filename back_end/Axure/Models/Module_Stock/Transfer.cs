using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock
{
    public class Transfer
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateT { get; set; }
        [Required]
        [StringLength(200)]
        public string Observation { get; set; }
        [Required]
        public int IdDepositOrigin { get; set; }
        [ForeignKey("IdDepositOrigin")]
        public Deposit DepositOr { get; set; }
        [Required]
        public int IdDepositDestination { get; set; }
        [ForeignKey("IdDepositDestination")]
        public Deposit DepositDes { get; set; }
        [Required]
        public int IdTransferType { get; set; }
        [ForeignKey("IdTransferType")]
        public TransferType TransferType { get; set; }
    }
}