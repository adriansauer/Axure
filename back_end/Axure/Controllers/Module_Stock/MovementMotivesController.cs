﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    public class MovementMotivesController : Controller
    {
        // GET: MovementMotives
        public ActionResult Index()
        {
            return View();
        }

        // GET: MovementMotives/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MovementMotives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovementMotives/Create
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

        // GET: MovementMotives/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MovementMotives/Edit/5
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

        // GET: MovementMotives/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MovementMotives/Delete/5
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
