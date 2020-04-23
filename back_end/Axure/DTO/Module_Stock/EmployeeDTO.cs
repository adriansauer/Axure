using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * EmployeeDTO class
 * Created april 20, 2020 by Victor Ciceia.
 */
namespace Axure.DTO.Module_Stock
{
    public class EmployeeDTO
    {
        //Unique identifier.
        public int Id { get; set; }

        //Employee name.
        public string Name { get; set; }

        //Employee CI.
        public string CI { get; set; }

        //Employe address.
        public string Address { get; set; }

        //Employee RUC.
        public string RUC { get; set; }

        //Employee phone.
        public string Phone { get; set; }
    }
}