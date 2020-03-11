using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock
{
    public class ComprobantePurchase
    {
        //ID
        public int Id { get; set; }
        //Fecha de compra
        [Required]
        public DateTime DateC { get; set; }
        //Id del proveedor
        [Required]
        public int IdProvider { get; set; }
        [ForeignKey("IdProvider")]
        public Provider Provider { get; set; }
        //Id encargado
        [Required]
        public int IdEmployee { get; set; }
        [ForeignKey("IdEmployee")]
        public Employee Employee { get; set; }
        //Codigo de identificacion de Comprobante de Compra
        [Required]
        [StringLength(50)]
        public string Code { get; set; }

    }
}