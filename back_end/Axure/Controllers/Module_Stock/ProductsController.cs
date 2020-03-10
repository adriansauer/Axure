using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 * Controlador  ProductsController
 * Creado el 10-03-2020 por Victor Ciceia.
 * Maneja todas las peticiones respecto a los producto.
 */
namespace Axure.Controllers.Module_Stock
{
    [RoutePrefix("Products")]
    public class ProductsController : Controller
    {
        //Atributos.
        public ProductsDB productsDB;
        
        //Constructor de la clase.
        public ProductsController()
        {
            this.productsDB = new ProductsDB();
        }

        // GET: Datos del modelo producto.
        //[Authorize(Roles = "user, admin")]
        [Route("Index")]
        public JsonResult Index()
        {
            return Json(new {Nombre = "Nombre", Descripcion = "Descripcion", Costo= "Costo", CantiddadMinima= "CantiddadMinima", CodigoBarra = "CodigoBarra" }, JsonRequestBehavior.AllowGet);
        }

        // GET: Todos los prodductos existentes.
        [Route("Everybody")]
        public JsonResult Everybody()
        {
            return Json(this.productsDB.ObtenerTodosProductos(), JsonRequestBehavior.AllowGet);
        }

        // GET: Todos los prodductos existentes en un deposito en especifico.
        [Route("OfDeposit/{deposit}")]
        public JsonResult OfDeposit(string deposit)
        {
            return Json(new { R = deposit }, JsonRequestBehavior.AllowGet);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
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

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Products/Edit/5
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

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
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
