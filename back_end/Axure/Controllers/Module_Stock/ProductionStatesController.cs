using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    [RoutePrefix("ProductionStates")]
    public class ProductionStatesController : Controller
    {
        //Atributos.
        /*private ProductionStateDB productionStateDB;

        //Constructor de la clase.
        public ProductionStatesController()
        {
            this.productionStateDB = new ProductionStateDB();
        }

        // GET: ProductionStates
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", StateP = "True" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(202);
            }
        }

        // GET: Todos los tipos de estados de produccion existentes.
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.productionStateDB.ObtenerTodosLosEstadosProduccion();
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

        // GET: ProductionStates/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.productionStateDB.DetalleDelEstadoProduccion(id);
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

        // GET: ProductionStates/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(ProductionStateDTO pt)
        {
            try
            {
                if (this.productionStateDB.Agregar(pt))
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

        // POST: ProductionStates/Create
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, ProductionStateDTO pt)
        {
            try
            {
                if (this.productionStateDB.Editar(id, pt))
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


        // POST: ProductionStates/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.productionStateDB.darDeBaja(id))
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
