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
        public int IdProductionState { get; set; }
        //
        public int IdProduct { get; set; }
        //
        public int IdEmployee { get; set; }
        //
        public DateTime DateT { get; set; }
        //
        public int Quantity { get; set; }
        //Codigo de identificacion de orden de produccion
        public string Code { get; set; }
        //
        public List<ProductionOrderDetail> ListaComponentes { get; set; }
    }
}