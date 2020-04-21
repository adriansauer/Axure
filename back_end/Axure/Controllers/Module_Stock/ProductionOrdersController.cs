using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    public class ProductionOrdersController : Controller
    {

        //Atributos.
        /*private ProductionOrderDB productionOrderDB;

        //Constructor de la clase.
        public ProductionOrdersController()
        {
            this.productionOrderDB = new ProductionOrderDB();
        }

        // GET: ProductionOrders
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", IdProductionState = "True", IdProduct = "True", IdEmployee = "True", DateT = "True", Quantity = "True", Code = "True", ListDetails = "True" }, JsonRequestBehavior.AllowGet);
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
                var lista = this.productionOrderDB.ObtenerTodasOrdenesProduccion();
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

        // GET: ProductionOrders/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.productionOrderDB.DetalleOrdenProduccion(id);
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
        
        // POST: ProductionOrders/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(ProductionOrderDTO po)
        {
            try
            {
                if (this.productionOrderDB.Agregar(po))
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

        // POST: ProductionOrders/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, ProductionOrderDTO po)
        {
            try
            {
                if (this.productionOrderDB.Editar(id, po))
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

        // DELETE: ProductionOrders/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.productionOrderDB.darDeBaja(id))
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
