using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Axure.Models.Module_Stock;

/*
 *Clase User
 * Creado el 1 de marzo de 2020 por Victor Ciceia.
 * Modelo de un usuario del sistema que se guarda en la base de datos.
 */
namespace Axure.Models
{
    public class User
    {
        //Id
        public int Id { get; set; }
        //El rol del usuario ej. user, admin, etc.
        [Required]
        [StringLength(50)]
        public string Role { get; set; }
        //El nombre del usuario.
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        //La contrasena.
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        //El estado del usuario, si esta conectado o no.
        [Required]
        public bool Status { get; set; }
        //El dueno de la cuenta de usuario que es un empleado de la empresa.
        [Required]
        public int IdEmployee { get; set; }
        [ForeignKey("IdEmployee")]
        public Employee Employee { get; set; }
    }
}