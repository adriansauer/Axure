using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 * ProductComponentsController class
 * Created april 21, 2020 by Victor Ciceia.
 */
namespace Axure.Controllers.Module_Stock
{
   // [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("ProductComponents")]
    public class ProductComponentsController : Controller
    {

        private ComponentDAO componentDAO;

        //Constructor de la clase.
        public ProductComponentsController()
        {
            this.componentDAO = new ComponentDAO();
        }

        // GET: ProductComponents
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", ProductId = "True", ProductComponentId = "True", Quantity = "True" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(202);
            }
        }

        // GET: ProductComponents/List
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.componentDAO.GetAll();
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

        // GET: ProductComponents/OfProduct
        [Route("OfProduct/{id}")]
        public ActionResult OfProduct(int id)
        {
            try
            {
                var lista = this.componentDAO.GetComponentOfProduct(id);
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
                var dato = this.componentDAO.Detail(id);
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
                if (this.componentDAO.Add(pct))
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
                if (this.componentDAO.Edit(id, pct))
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
                if (this.componentDAO.Delete(id))
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
