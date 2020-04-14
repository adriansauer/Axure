using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Stock
{
    public class EmployeeDB
    {
        public EmployeeDB()
        {
        }

        /*
         * Metodo ObtenerTodosProductos, retorna todos los productos que tiene registrado.
        */
        public List<EmployeeDTO> ObtenerTodosLosEmpleados()
        {
            try
            {
                using (var db = new AxureContext())
                {

                    var respuesta = db.Employees.Where(x => x.Delete == false)
                        .Select(x => new { Id = x.Id, NameE = x.NameE, CI = x.CI, Direction = x.Direction, RUC = x.RUC, Phone = x.Phone })
                        .ToList()
                        .Select(y => new EmployeeDTO() { Id = y.Id, NameE = y.NameE, CI = y.CI, Direction = y.Direction, RUC = y.RUC, Phone = y.Phone })
                        .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public EmployeeDTO DetalleDelEmpleado(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var e = db.Employees.FirstOrDefault(x => x.Id == id && x.Delete == false);
                    return new EmployeeDTO() { Id = e.Id, NameE = e.NameE, CI = e.CI, Direction = e.Direction, RUC = e.RUC, Phone = e.Phone };
                }
            }
            catch
            {
                return null;
            }

        }


        public bool Agregar(EmployeeDTO e)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.Employees.Add(new Employee { NameE = e.NameE, CI = e.CI, Direction =e.Direction, RUC = e.RUC, Phone = e.Phone, Delete = false});
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }


        public bool Editar(int id, EmployeeDTO e)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Employee empEditado = db.Employees.FirstOrDefault(x => x.Id == id);
                    empEditado.NameE = e.NameE;
                    empEditado.CI = e.CI;
                    empEditado.Direction = e.Direction;
                    empEditado.Phone = e.Phone;
                    empEditado.RUC = e.RUC;
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool darDeBaja(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Employee e = db.Employees.FirstOrDefault(x => x.Id == id);
                    e.Delete = true;
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Employee e = db.Employees.Single(x => x.Id == id);
                    if (null == e) { return true; }
                    db.Employees.Remove(e);
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }
    }
}