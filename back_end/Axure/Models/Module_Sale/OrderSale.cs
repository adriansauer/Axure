using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * OrderSale class
 * Created May 13, 2020 by Victor Ciceia.
 * Products sale order.
 */
namespace Axure.Models.Module_Sale
{
    public class OrderSale
    {
        //Unique indentifier.
        public int Id { get; set; }

        //Client who placed the order.
        [Required]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        //Order state.
        [Required]
        public int StateOrderSaleId { get; set; }
        [ForeignKey("StateOrderSaleId")]
        public StateOrderSale StateOrderSale { get; set; }

        //Employee responsible for the order sale.
        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        //Order number.
        [Required]
        [StringLength(20)]
        public string OrderNumber { get; set; }

        //Create date.
        [Required]
        public DateTime Date { get; set; }

        //Used to remove ilde.
        [Required]
        public bool Deleted { get; set; }
    }
}