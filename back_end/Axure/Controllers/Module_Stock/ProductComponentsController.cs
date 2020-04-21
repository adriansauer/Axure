using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    [RoutePrefix("ProductComponents")]
    public class ProductComponentsController : Controller
    {
        //Atributos.
       /* private ComponentDB componentDB;

        //Constructor de la clase.
        public ProductComponentsController()
        {
            this.componentDB = new ComponentDB();
        }

        // GET: ProductComponents
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", NameE = "True", CI = "True", Direction = "True", RUC = "True", Phone = "True" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(202);
            }
        }

        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.componentDB.ObtenerTodosLosComponentes();
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

        [Route("OfProduct/{id}")]
        public ActionResult OfProduct(int id)
        {
            try
            {
                var lista = this.componentDB.ObtenerTodosLosComponentesDeUnProducto(id);
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

        // GET: ProductComponents/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.componentDB.DetalleDelComponente(id);
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

        // POST: ProductComponents/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(ProductComponentDTO pct)
        {
            try
            {
                if (this.componentDB.Agregar(pct))
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

        // POST: ProductComponents/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, ProductComponentDTO pct)
        {
            try
            {
                if (this.componentDB.Editar(id, pct))
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

        // DELETE: ProductComponents/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.componentDB.darDeBaja(id))
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
        }*/
    }
}
