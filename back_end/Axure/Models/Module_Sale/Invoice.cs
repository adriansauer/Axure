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

        //Invoice state.
        [Required]
        public int StateInvoiceId { get; set; }
        [ForeignKey("StateInvoiceId")]
        public StateInvoice StateInvoice { get; set; }

        //Invoice payment term
        [Required]
        public int PaymentTermId { get; set; }
        [ForeignKey("PaymentTermId")]
        public PaymentTerm PaymentTerm { get; set; }

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

        //Total amount with IVA.
        [Required]
        public int Total { get; set; }

        //Total amount of IVA 10%.
        [Required]
        public int TotalIVA10 { get; set; }

        //Total amount of IVA 5%.
        [Required]
        public int TotalIVA5 { get; set; }

        //Total amount exempt from tax. 
        [Required]
        public string TotalExempt { get; set; }
    }
}