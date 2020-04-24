using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 * ProductionStatesController class
 * Created april 21, 2020 by Victor Ciceia.
 */
namespace Axure.Controllers.Module_Stock
{
    [RoutePrefix("ProductionStates")]
    public class ProductionStatesController : Controller
    {
        private ProductionStateDAO productionStateDAO;

        public ProductionStatesController()
        {
            this.productionStateDAO = new ProductionStateDAO();
        }

        // GET: ProductionStates
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", State = "True" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
            }
        }

        // GET: Todos los tipos de estados de produccion existentes.
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.productionStateDAO.GetAll();
                if (null != lista)
                {
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
                return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }
        }

        // GET: ProductionStates/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.productionStateDAO.Detail(id);
                if (null != dato)
                {
                    return Json(dato, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }
        }

        // GET: ProductionStates/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(ProductionStateDTO pt)
        {
            try
            {
                if (this.productionStateDAO.Add(pt))
                {
                    return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
                }
                else
                {
                    return new HttpStatusCodeResult(CodeHTTP.OK);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }
        }

        // POST: ProductionStates/Create
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, ProductionStateDTO pt)
        {
            try
            {
                if (this.productionStateDAO.Edit(id, pt))
                {
                    return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
                }
                else
                {
                    return new HttpStatusCodeResult(CodeHTTP.OK);
                }
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }
        }

        // POST: ProductionStates/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.productionStateDAO.Remove(id))
                {
                    return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
                }
                else
                {
                    return new HttpStatusCodeResult(CodeHTTP.OK);
                }

            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }
        }
    }
}
