using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class DepositDTO
    {
        //Nombre del deposito.
        [Required]
        [StringLength(50)]
        public string NameD { get; set; }
        //Codigo identificador del deposito.
        [Required]
        public string Code { get; set; }
    }
}