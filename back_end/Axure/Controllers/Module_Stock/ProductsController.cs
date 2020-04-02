using Axure.DataBase;
using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using Axure.Models.Module_Stock.Models;
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
        private ProductsDB productsDB;

        //Constructor de la clase.
        public ProductsController()
        {
            this.productsDB = new ProductsDB();
        }

        // GET: Datos del modelo producto.
        //[Authorize(Roles = "user, admin")]
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", ProductType = "True", NameP = "True", DescriptionP = "True", Cost = "True", Quantity = "True", Barcode = "True" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(202);
            }
        }

        // GET: Todos los prodductos existentes.
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.productsDB.ObtenerTodosProductos();
                if(null != lista)
                {
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
                return new HttpStatusCodeResult(202);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
           
        }

        // GET: Todos los prodductos existentes en un deposito en especifico.
        [Route("OfDeposit/{id}")]
        public ActionResult OfDeposit(int id)
        {
            try
            {
                var lista = this.productsDB.ProductosPorDeposito(id);
                if (null != lista)
                {
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
                return new HttpStatusCodeResult(202);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
            
        }

        // GET: Products/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.productsDB.DetalleProducto(id);
                if (null != dato)
                {
                    return Json(dato, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return new HttpStatusCodeResult(202);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        // GET: Products/SumDeposit/5
        [Route("SumDeposit/{id}")]
        public ActionResult SumDeposit(int id)
        {
            try
            {
                return Json(new { Sum = this.productsDB.SumaPrecioProductoDeposito(id) }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

          // POST: Products/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Pc pc)
        {
            try
            {
                if(null == pc.listaComponentes)
                {
                    if(this.productsDB.Agregar(pc))
                        return new HttpStatusCodeResult(406);
                }
                else
                {
                    if(this.productsDB.AgregarPcComponentes(pc))
                        return new HttpStatusCodeResult(406);
                }
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
        public ActionResult Edit(int id, Product prod)
        {
            try
            {
                if (this.productsDB.Editar(id, prod))
                {
                    return new HttpStatusCodeResult(406);
                }
                else
                {
                    return new HttpStatusCodeResult(200);
                }
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
                if (this.productsDB.darDeBaja(id))
                {
                    return new HttpStatusCodeResult(406);
                }
                else
                {
                    return new HttpStatusCodeResult(200);
                }
                
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }
    }
}
