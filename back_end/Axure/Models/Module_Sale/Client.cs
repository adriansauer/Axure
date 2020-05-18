using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * Client class
 * Created May 13, 2020 by Victor Ciceia.
 * Clients making purchases.
 */
namespace Axure.Models.Module_Sale
{
    public class Client
    {
        //Unique identifier.
        public int Id { get; set; }

        //Client name.
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        //Client address.
        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        //Client number RUC.
        [Required]
        [StringLength(20)]
        public string RUC { get; set; }

        //Maximum credit the client can get.
        [Required]
        public int CreditMaximum { get; set; }

        //Current customer credit.
        [Required]
        public int CreditPending { get; set; }

        //Used to remove idle.
        [Required]
        public bool Deleted { get; set; }
    }
}