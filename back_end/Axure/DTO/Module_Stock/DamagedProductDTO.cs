using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class DamagedProductDTO
    {
        //FECHA
        public DateTime DateD { get; set; }
        //Id del producto
        [Required]
        public int IdProduct { get; set; }
        //Cantidad
        [Required]
        public int Quantity { get; set; }
        //Razon
       
        [StringLength(50)]
        public string Reason { get; set; }
    }
}