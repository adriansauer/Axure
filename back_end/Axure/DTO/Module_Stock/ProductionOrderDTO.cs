using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class ProductionOrderDTO
    {
        //
        public int Id { get; set; }
        //
        [Required]
        public int IdProductionState { get; set; }
        //
        [Required]
        public int IdProduct { get; set; }
        //
        public int IdEmployee { get; set; }
        //
        [Required]
        public DateTime DateT { get; set; }
        //
        [Required]
        public int Quantity { get; set; }
        //Codigo de identificacion de orden de produccion
        [StringLength(50)]
        public string Code { get; set; }
        //
        public List<ProductionOrderDetail> ListaComponentes { get; set; }
    }
}