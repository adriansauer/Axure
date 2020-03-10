using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 *Clase Employee
 * Creado el 1 de marzo de 2020 por Victor Ciceia.
 * Modelo de los datos que posee un empleado de la empresa,
 * este modelo es utilizado por la base de datos.
 */
namespace Axure.Models.Module_Stock
{
    public class Employee
    {
        //Id.
        public int Id { get; set; }
        //Nombre del empleado.
        [Required]
        [StringLength(200)]
        public string NameE { get; set; }
        //Ceddula de identidad.
        [Required]
        [StringLength(20)]
        public string CI { get; set; }
        //La direccion del empleado.
        [Required]
        [StringLength(200)]
        public string Direction { get; set; }
        //El RUC del empleado.
        [Required]
        [StringLength(20)]
        public string RUC { get; set; }
        //El numero de celular o telefono del empleado.
        [StringLength(20)]
        public string Phone { get; set; }
    }
}