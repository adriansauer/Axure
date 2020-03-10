using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    public class TransfersController : Controller
    {
        // GET: Transfers
        public ActionResult Index()
        {
            return View();
        }

        // GET: Transfers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Transfers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transfers/Create
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

        // GET: Transfers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Transfers/Edit/5
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

        // GET: Transfers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transfers/Delete/5
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
