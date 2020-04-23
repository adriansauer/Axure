using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * Provider class
 * Created march 1, 2020 by Victor Ciceia.
 * Raw material suppliers.
 */
namespace Axure.Models.Module_Stock
{
    public class Provider
    {
        //Unique identifier.
        public int Id { get; set; }

        //Provider name.
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        //Provider address.
        [StringLength(200)]
        public string Address { get; set; }

        //Provider phone.
        [StringLength(20)]
        public string Phone { get; set; }

        //Credit that the company has available with the supplier.
        [Required]
        public int Credit { get; set; }

        //Provider RUC.
        [StringLength(20)]
        public string RUC { get; set; }

        //Used to remove ilde.
        [Required]
        public bool Deleted { get; set; }
    }
}