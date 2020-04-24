using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 * StoksController class
 * Created april 21, 2020 by Victor Ciceia.
 */
namespace Axure.Controllers.Module_Stock
{
   // [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("Stocks")]
    public class StocksController : Controller
    {

        //Attributes
        StockDAO stockDAO;

        public StocksController()
        {
            this.stockDAO = new StockDAO();
        }

        // GET: Stocks
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", DepositId = "True", ProductId = "True", Quantity = "True"}, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
            }
        }

        // GET: Stocks/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.stockDAO.Detail(id);
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

        // GET: Stocks/Quantity/5
        [Route("Quantity/{id}")]
        public ActionResult Quantity(int id, Deposit dep)
        {
            try
            {
                return Json(new { Quantity = this.stockDAO.ProductQuantity(id, dep) }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }
        }

        // POST: Stocks/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(StockDTO st)
        {
            try
            {               
                if (this.stockDAO.Add(st))
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

        // PUT: Stocks/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, StockDTO st)
        {
            try
            {
                if (this.stockDAO.Edit(id, st))
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

        // DELETE: Stocks/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.stockDAO.Remove(id))
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
