using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Sale
{
    public class OrderSalesController : Controller
    {
        // GET: OrderSales
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderSales/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderSales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderSales/Create
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

        // GET: OrderSales/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderSales/Edit/5
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

        // GET: OrderSales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderSales/Delete/5
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
