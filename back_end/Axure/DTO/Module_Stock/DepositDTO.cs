using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * DepositDTO class
 * Created april 20, 2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Stock
{
    public class DepositDTO
    {
        //Unique identifier.
        public int Id { get; set; }
        //Deposit name.
        public string Name { get; set; }
    }
}