using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 *Clase TransferType
 * Creado el 1 de marzo de 2020 por Victor Ciceia.
 * Modelo de la descripcion del motivo por el cual se realiza el traslado un producto, 
 * este modelo es utilizado para la base de datos.
 */
namespace Axure.Models.Module_Stock
{
    public class TransferType
    {
        //Id.
        public int Id { get; set; }
        //Descipcion del motivo del traslado.
        [Required]
        [StringLength(50)]
        public string TypeP { get; set; }
    }
}