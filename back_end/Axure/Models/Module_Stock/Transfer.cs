using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 *Clase ProductType
 * Creado el 1 de marzo de 2020 por Victor Ciceia.
 * Modelo de una transferencia de un producto de un deposito a otro,
 * este modelo es utilizado por la base de datos.
 */
namespace Axure.Models.Module_Stock
{
    public class Transfer
    {
        //Id.
        public int Id { get; set; }
        //FK del deposito de donde sale el producto.
        [Required]
        public int IdDepositOrigin { get; set; }
        [ForeignKey("IdDepositOrigin")]
        public Deposit DepositOr { get; set; }
        //FK del deposito en donde se traslada.
        [Required]
        public int IdDepositDestination { get; set; }
        [ForeignKey("IdDepositDestination")]
        public Deposit DepositDes { get; set; }
        //FK de los detalles de los productos que se esta trasladando.
        [Required]
        public int IdTransferType { get; set; }
        [ForeignKey("IdTransferType")]
        public TransferType TransferType { get; set; }
        //La fecha del traslado.
        [Required]
        public DateTime DateT { get; set; }
        //Observaciones que puede tener el traslado.
        [StringLength(200)]
        public string Observation { get; set; }
        //Numero de trans1ferencia
        [Required]
        public int Number { get; set; }
    }
}