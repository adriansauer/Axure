using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 *Clase TransferDetail
 * Creado el 1 de marzo de 2020 por Victor Ciceia.
 * Modelo que representa los detalles de una transferencia de un producto,
 * este modelo es utilizado para la base de datos.
 */
namespace Axure.Models.Module_Stock
{
    public class TransferDetail
    {
        //Id.
        public int Id { get; set; }
        //FK del producto el cual se esta trasladando de un deposito a otro.
        [Required]
        public int IdProduct { get; set; }
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }
        //FK de la tranferencia que se esta realizando.
        [Required]
        public int IdTransfer { get; set; }
        [ForeignKey("IdTransfer")]
        public Transfer Transfer { get; set; }
        //Cantidad del producto que se esta trasladando.
        [Required]
        public int Quantity { get; set; }
    }
}