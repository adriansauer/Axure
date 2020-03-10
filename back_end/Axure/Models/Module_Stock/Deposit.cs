using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 *Clase Deposit
 * Creado el 1 de marzo de 2020 por Victor Ciceia.
 * Depositos que posee la empresa.
 */
namespace Axure.Models.Module_Stock
{
    public class Deposit
    {
        //Id.
        public int Id { get; set; }
        //Nombre del deposito.
        [Required]
        [StringLength(50)]
        public string NameD { get; set; }
        //Codigo identificador del deposito.
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
    }
}