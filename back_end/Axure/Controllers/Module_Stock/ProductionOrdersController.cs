using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 * ProductionOrdersController class
 * Created april 22, 2020 by Victor Ciceia.
 */
namespace Axure.Controllers.Module_Stock
{
    [RoutePrefix("ProductionOrders")]
    public class ProductionOrdersController : Controller
    {

        private ProductionOrderDAO productionOrderDAO;

        public ProductionOrdersController()
        {
            this.productionOrderDAO = new ProductionOrderDAO();
        }

        // GET: ProductionOrders
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", ProductionStateId = "True", EmployeeId = "True", Date = "True", Quantity = "True", ListDetails = "True" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
            }
        }

        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.productionOrderDAO.GetAll();
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

        // GET: ProductionOrders/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.productionOrderDAO.Detail(id);
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
        
        // POST: ProductionOrders/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(ProductionOrderDTO po)
        {
            try
            {
                if (this.productionOrderDAO.Add(po))
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

        // POST: ProductionOrders/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, ProductionOrderDTO po)
        {
            try
            {
                if (this.productionOrderDAO.Edit(id, po))
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

        // DELETE: ProductionOrders/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.productionOrderDAO.Remove(id))
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
