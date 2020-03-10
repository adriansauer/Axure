using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    public class ComprobantePurchasesController : Controller
    {
        // GET: ComprobantePurchases
        public ActionResult Index()
        {
            return View();
        }

        // GET: ComprobantePurchases/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComprobantePurchases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComprobantePurchases/Create
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

        // GET: ComprobantePurchases/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComprobantePurchases/Edit/5
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

        // GET: ComprobantePurchases/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComprobantePurchases/Delete/5
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
