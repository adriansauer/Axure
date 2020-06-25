using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * ProviderInvoice class
 * Created June 25, 2020 by Victor Ciceia.
 * Provider invoice.
 */
namespace Axure.Models.Module_Purchase
{
    public class ProviderInvoice
    {
        //Unique identifier.
        public int Id { get; set; }

        //Provider identifier.
        [Required]
        public int ProviderId { get; set; }
        [ForeignKey("ProviderId")]
        public Provider Provider { get; set; }

        //Purchase order identifier.
        [Required]
        public int PurchaseOrderId { get; set; }
        [ForeignKey("PurchaseOrderId")]
        public PurchaseOrder PurchaseOrder { get; set; }

        //Invoice status 
        [StringLength(20)]
        public string Status { get; set; }

        //Invoice number 
        [StringLength(20)]
        public string InvoiceNumber { get; set; }

        //Provider name.
        [Required]
        [StringLength(100)]
        public string ProviderName { get; set; }

        //Provider RUC number.
        [Required]
        [StringLength(20)]
        public string ProviderRUC { get; set; }

        //Provider address.
        [Required]
        [StringLength(200)]
        public string ProviderAddress { get; set; }

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