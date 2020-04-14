using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Axure.DTO.Module_Stock
{
    public class EmployeeDTO
    {
        //Id.
        public int Id { get; set; }
        //Nombre del empleado.
        public string NameE { get; set; }
        //Ceddula de identidad.
        public string CI { get; set; }
        //La direccion del empleado.
        public string Direction { get; set; }
        //El RUC del empleado.
        public string RUC { get; set; }
        //El numero de celular o telefono del empleado.
        public string Phone { get; set; }
    }
}