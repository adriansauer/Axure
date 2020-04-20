using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * Employee class
 * Created March 1, 2020 by Victor Ciceia.
 * Company employees.
 */
namespace Axure.Models.Module_Stock
{
    public class Employee
    {
        //Unique identifier.
        public int Id { get; set; }

        //Employee name.
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        //Employee identity card.
        [Required]
        [StringLength(20)]
        public string CI { get; set; }

        //Employee address.
        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        //Employee RUC.
        [Required]
        [StringLength(20)]
        public string RUC { get; set; }

        //Employee phone.
        [StringLength(20)]
        public string Phone { get; set; }

        //Used to remove idle.
        [Required]
        public bool Deleted { get; set; }
    }
}