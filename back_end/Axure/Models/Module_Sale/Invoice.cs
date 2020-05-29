using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * Invoice class
 * Created May 13, 2020 by Victor Ciceia.
 * Company invoice.
 */
namespace Axure.Models.Module_Sale
{
    public class Invoice
    {
        //Unique identifier.
        public int Id { get; set; }

        //Orden sale.
        [Required]
        public int OrderSaleId { get; set; }
        [ForeignKey("OrderSaleId")]
        public OrderSale OrderSale { get; set; }

        //Employee responsible for the sale.
        [Required]
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        //Client identifier.
        [Required]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        //Invoice sale condition. 
        [StringLength(20)]
        public string SaleCondition { get; set; }

        //Invoice status 
        [StringLength(20)]
        public string Status { get; set; }

        //Invoice number 
        [StringLength(20)]
        public string InvoiceNumber { get; set; }

        //Client name.
        [Required]
        [StringLength(100)]
        public string ClientName { get; set; }

        //Client RUC number.
        [Required]
        [StringLength(20)]
        public string ClientRUC { get; set; }

        //Client address.
        [Required]
        [StringLength(200)]
        public string ClientAddress { get; set; }

        //Create date.
        [Required]
        public DateTime Date { get; set; }

        //Total amount with IVA.
        [Required]
        public int Total { get; set; }

        //Invoice tax total.
        [Required]
        public int TaxTotal { get; set; }
    }
}