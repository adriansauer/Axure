using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * EmployeeDAO class
 * Created april 20, 2020 by Victor Ciceia.
 */
namespace Axure.DataBase.Module_Stock
{
    public class EmployeeDAO
    {
        public EmployeeDAO()
        {
        }

        public List<EmployeeDTO> GetAll()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var respuesta = db.Employees.Where(x => x.Deleted == false)
                        .Select(x => new { Id = x.Id, Name = x.Name, CI = x.CI, Address = x.Address, RUC = x.RUC, Phone = x.Phone })
                        .ToList()
                        .Select(y => new EmployeeDTO() { Id = y.Id, Name = y.Name, CI = y.CI, Address = y.Address, RUC = y.RUC, Phone = y.Phone })
                        .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public EmployeeDTO Detail(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var e = db.Employees.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    return new EmployeeDTO() { Id = e.Id, Name = e.Name, CI = e.CI, Address = e.Address, RUC = e.RUC, Phone = e.Phone };
                }
            }
            catch
            {
                return null;
            }

        }


        public bool Add(EmployeeDTO e)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.Employees.Add(new Employee { Name = e.Name, CI = e.CI, Address =e.Address, RUC = e.RUC, Phone = e.Phone, Deleted = false});
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }


        public bool Edit(int id, EmployeeDTO e)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Employee empEditado = db.Employees.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    empEditado.Name = e.Name;
                    empEditado.CI = e.CI;
                    empEditado.Address = e.Address;
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

        public bool Remove(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Employee e = db.Employees.FirstOrDefault(x => x.Id == id);
                    e.Deleted = true;
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Delete(int id)
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