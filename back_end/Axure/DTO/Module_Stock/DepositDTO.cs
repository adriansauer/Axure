using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class DepositDTO
    {
        public int Id { get; set; }
        //Nombre del deposito.
        public string NameD { get; set; }
        //Codigo identificador del deposito.
        public string Code { get; set; }
    }
}