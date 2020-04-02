using Axure.DataBase.Module_Stock;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    [RoutePrefix("Stocks")]
    public class StocksController : Controller
    {

        //Atributos
        StockDB stockDB;

        public StocksController()
        {
            this.stockDB = new StockDB();
        }

        // GET: Stocks
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", IdDeposit = "True", IdProduct = "True", Quantity = "True"}, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(202);
            }
        }

        // GET: Stocks/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.stockDB.DetalleStock(id);
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


        // GET: Stocks/Quantity/5
        [Route("Quantity/{id}")]
        public ActionResult Quantity(int id, Deposit dep)
        {
            try
            {
                return Json(new { Quantity = this.stockDB.CantidadProducto(id, dep) }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        // POST: Stocks/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Stock st)
        {
            try
            {               
                if (this.stockDB.Agregar(st))
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

        // POST: Stocks/Edit/5
        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, Stock st)
        {
            try
            {
                if (this.stockDB.Editar(id, st))
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

        // POST: Stocks/Delete/5
        [HttpPost]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.stockDB.Eliminar(id))
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
