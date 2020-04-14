using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    [RoutePrefix("Employees")]
    public class EmployeesController : Controller
    {
        //Atributos.
        private EmployeeDB employeeDB;

        //Constructor de la clase.
        public EmployeesController()
        {
            this.employeeDB = new EmployeeDB();
        }

        // GET: Datos del modelo de un empleado.
        //[Authorize(Roles = "user, admin")]
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", NameE = "True", CI = "True", Direction = "True", RUC = "True", Phone = "True" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(202);
            }
        }

        // GET: Todos los tipos de productos existentes.
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.employeeDB.ObtenerTodosLosEmpleados();
                if (null != lista)
                {
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
                return new HttpStatusCodeResult(202);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }

        }

        // GET: Employees/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.employeeDB.DetalleDelEmpleado(id);
                if (null != dato)
                {
                    return Json(dato, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return new HttpStatusCodeResult(202);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        // POST: Employees/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(EmployeeDTO e)
        {
            try
            {
                if (this.employeeDB.Agregar(e))
                {
                    return new HttpStatusCodeResult(406);
                }
                else
                {
                    return new HttpStatusCodeResult(200);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        // POST: Employees/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, EmployeeDTO e)
        {
            try
            {
                if (this.employeeDB.Editar(id, e))
                {
                    return new HttpStatusCodeResult(406);
                }
                else
                {
                    return new HttpStatusCodeResult(200);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        // DELETE: Employees/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.employeeDB.darDeBaja(id))
                {
                    return new HttpStatusCodeResult(406);
                }
                else
                {
                    return new HttpStatusCodeResult(200);
                }

            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }
    }
}
