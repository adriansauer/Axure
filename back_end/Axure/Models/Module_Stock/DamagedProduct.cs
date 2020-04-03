using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
/*
 * Creado por Enzo Ramirez
 * 30-03-2020
 */
namespace Axure.Models.Module_Stock
{
    public class DamagedProduct
    {
        //ID
        public int Id { get; set; }
        //FECHA
        public DateTime DateD { get; set; }
        //Id del producto
        [Required]
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }
        //Cantidad
        [Required]
        public int Quantity { get; set; }
        //Razon
        [Required]
        [StringLength(50)]
        public string Reason { get; set; }
        
        //Por si se necesita
        /*
        [Required]
        public int IdEmployee { get; set; }
        [ForeignKey("IdEmployee")]
        public Employee Employee { get; set; }*/
    }
}