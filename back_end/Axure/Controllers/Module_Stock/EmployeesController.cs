using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 * EmployeesController class
 * Created april 21, 2020 by Victor Ciceia.
 */
namespace Axure.Controllers.Module_Stock
{
<<<<<<< HEAD
=======
   // [EnableCors(origins: "*", headers: "*", methods: "*")]
>>>>>>> master
    [RoutePrefix("Employees")]
    public class EmployeesController : Controller
    {

        private EmployeeDAO employeeDAO;

        public EmployeesController()
        {
            this.employeeDAO = new EmployeeDAO();
        }

        // GET: Employees
        //[Authorize(Roles = "user, admin")]
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", Name = "True", CI = "True", Address = "True", RUC = "True", Phone = "True" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
            }
        }

        // GET: Employees/List
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.employeeDAO.GetAll();
                if (null != lista)
                {
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
                return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }

        }

        // GET: Employees/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.employeeDAO.Detail(id);
                if (null != dato)
                {
                    return Json(dato, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }
        }

        // POST: Employees/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(EmployeeDTO e)
        {
            try
            {
                if (this.employeeDAO.Add(e))
                {
                    return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
                }
                else
                {
                    return new HttpStatusCodeResult(CodeHTTP.OK);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }
        }

        // POST: Employees/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, EmployeeDTO e)
        {
            try
            {
                if (this.employeeDAO.Edit(id, e))
                {
                    return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
                }
                else
                {
                    return new HttpStatusCodeResult(CodeHTTP.OK);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }
        }

        // DELETE: Employees/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.employeeDAO.Remove(id))
                {
                    return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
                }
                else
                {
                    return new HttpStatusCodeResult(CodeHTTP.OK);
                }

            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }
        }
    }
}
