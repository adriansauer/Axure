﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * IncomeCredit class
 * Created May 13, 2020 by Victor Ciceia.
 * Fee of a invoice.
 */
namespace Axure.Models.Module_Sale
{
    public class Fee
    {
        //Unique identifier.
        public int Id { get; set; }

        //Credit of a invoice.
        [Required]
        public int DebtId { get; set; }
        [ForeignKey("DebtId")]
        public Debt Debt { get; set; }

        //Fee number.
        [Required]
        public int FeeNumber { get; set; }

        //Fee amount.
        [Required]
        public int Amount { get; set; }

        //Payment date.
        [Required]
        public DateTime PaymentDate { get; set; }

        //Expiration date.
        [Required]
        public DateTime ExpirationDate { get; set; }

        //Fee status
        [Required]
        public string Status { get; set; }




    }
}