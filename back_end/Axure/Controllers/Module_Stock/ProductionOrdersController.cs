using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    public class ProductionOrdersController : Controller
    {
        // GET: ProductionOrders
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductionOrders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductionOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductionOrders/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductionOrders/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductionOrders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductionOrders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductionOrders/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
