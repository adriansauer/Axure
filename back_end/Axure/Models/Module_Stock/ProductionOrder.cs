using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Axure.Models.Module_Stock
{
    public class ProductionOrder
    {
        //
        public int Id { get; set; }
        //
        [Required]
        public int IdProductionState { get; set; }
        [ForeignKey("IdProductionState")]
        public ProductionState ProductionState { get; set; }
        //
        [Required]
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }
        //
        [Required]
        public int IdEmployee { get; set; }
        [ForeignKey("IdEmployee")]
        public Employee Employee { get; set; }
        //
        [Required]
        public DateTime DateT { get; set; }
        //
        [Required]
        public int Quantity { get; set; }
        //Codigo de identificacion de orden de produccion
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        //
        [Required]
        public bool Delete { get; set; }
    }
}