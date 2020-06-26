using Axure.DataBase.Module_Purchase;
using Axure.DTO.Module_Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Purchase
{
    [RoutePrefix("PurchaseOrders")]
    public class PurchaseOrdersController : Controller
    {
        private PurchaseOrderDAO purchaseOrderDAO;

        public PurchaseOrdersController()
        {
            this.purchaseOrderDAO = new PurchaseOrderDAO();
        }


        // GET: PurchaseOrders
        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.purchaseOrderDAO.List();
                if (null != lista)
                {
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
                return new HttpStatusCodeResult(200);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return new HttpStatusCodeResult(406);
            }
        }

        // GET: PurchaseOrders/Details/5
        [HttpGet]
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var lista = this.purchaseOrderDAO.GetById(id);
                if (null != lista)
                {
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
                return new HttpStatusCodeResult(200);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return new HttpStatusCodeResult(406);
            }
        }

        // POST: PurchaseOrders/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(PurchaseOrderDetailsDTO po)
        {
            try
            {
                if (this.purchaseOrderDAO.Add(po))
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

        // POST: PurchaseOrders/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (true)
                //if (this.purchaseOrderDAO.Remove(id))
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
