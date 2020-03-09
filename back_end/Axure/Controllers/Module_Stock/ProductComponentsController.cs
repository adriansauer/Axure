using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    public class ProductComponentsController : Controller
    {
        // GET: ProductComponents
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductComponents/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductComponents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductComponents/Create
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

        // GET: ProductComponents/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductComponents/Edit/5
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

        // GET: ProductComponents/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductComponents/Delete/5
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
