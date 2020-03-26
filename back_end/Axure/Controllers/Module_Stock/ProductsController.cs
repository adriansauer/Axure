using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
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
            return Json(new {Id = "False", IdProductType = "True", NameP= "True", DescriptionP= "True", Cost = "True", Quantity = "True", Barcode = "False" }, JsonRequestBehavior.AllowGet);
        }

        // GET: Todos los prodductos existentes.
        [Route("List")]
        public JsonResult List()
        {
            return Json(this.productsDB.ObtenerTodosProductos(), JsonRequestBehavior.AllowGet);
        }

        // GET: Todos los prodductos existentes en un deposito en especifico.
        [Route("OfDeposit/{id}")]
        public JsonResult OfDeposit(int id)
        {
            return Json(this.productsDB.ProductosPorDeposito(id), JsonRequestBehavior.AllowGet);
        }

        // GET: Products/Details/5
        [Route("Details/{id}")]
        public JsonResult Details(int id)
        {
            return Json(this.productsDB.DetalleProducto(id), JsonRequestBehavior.AllowGet);
        }

        // GET: Products/SumDeposit/5
        [Route("SumDeposit/{id}")]
        public JsonResult SumDeposit(int id)
        {
            return Json(new { Sum = this.productsDB.SumaPrecioProductoDeposito(id) }, JsonRequestBehavior.AllowGet);
        }

        // POST: Products/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                this.productsDB.Agregar(collection["NameP"], Int32.Parse(collection["IdProductType"]), collection["DescriptionP"], Int32.Parse(collection["Cost"]), Int32.Parse(collection["QuantityMin"]), collection["Barcode"]);
                return new HttpStatusCodeResult(200);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        // POST: Products/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                this.productsDB.Editar(id, collection["NameP"], Int32.Parse(collection["IdProductType"]), collection["DescriptionP"], Int32.Parse(collection["Cost"]), Int32.Parse(collection["QuantityMin"]), collection["Barcode"]);
                return new HttpStatusCodeResult(200);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        // POST: Products/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                this.productsDB.darDeBaja(id);
                return new HttpStatusCodeResult(200);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }
    }
}
