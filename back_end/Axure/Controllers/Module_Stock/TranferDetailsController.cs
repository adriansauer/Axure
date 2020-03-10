using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    public class TranferDetailsController : Controller
    {
        // GET: TranferDetails
        public ActionResult Index()
        {
            return View();
        }

        // GET: TranferDetails/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TranferDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TranferDetails/Create
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

        // GET: TranferDetails/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TranferDetails/Edit/5
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

        // GET: TranferDetails/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TranferDetails/Delete/5
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
