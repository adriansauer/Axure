using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    public class ProductionStatesController : Controller
    {
        // GET: ProductionStates
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductionStates/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductionStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductionStates/Create
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

        // GET: ProductionStates/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductionStates/Edit/5
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

        // GET: ProductionStates/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductionStates/Delete/5
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
