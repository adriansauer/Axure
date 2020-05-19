using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * IncomeDetail class
 * Created May 13, 2020 by Victor Ciceia.
 * Income detail of a fee.
 */
namespace Axure.Models.Module_Sale
{
    public class IncomeDetail
    {
        //Unique identifier.
        public int Id { get; set; }

        //Payment of a fee.
        [Required]
        public int FeeCreditId { get; set; }
        [ForeignKey("FeeCreditId")]
        public FeeCredit FeeCredit { get; set; }

        //Type of payment.
        [Required]
        public int IncomeTypeId { get; set; }
        [ForeignKey("IncomeTypeId")]
        public IncomeType IncomeType { get; set; }

        //Income amount.
        [Required]
        public int Amount { get; set; }
    }
}