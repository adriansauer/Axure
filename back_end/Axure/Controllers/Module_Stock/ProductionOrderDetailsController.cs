using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 * ProductionOrderDetailsController class
 * Created april 22, 2020 by Victor Ciceia.
 */
namespace Axure.Controllers.Module_Stock
{
<<<<<<< HEAD
=======
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
>>>>>>> master
    [RoutePrefix("ProductionOrderDetails")]
    public class ProductionOrderDetailsController : Controller
    {

        private ProductionOrderDetailDAO productionOrderDetailDAO;

        public ProductionOrderDetailsController()
        {
            this.productionOrderDetailDAO = new ProductionOrderDetailDAO();
        }

        // GET: ProductionOrderDetails
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", ProductionOrderId = "True", ProductId = "True", Quantity = "True" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
            }
        }

        // GET: ProductionOrderDetails/GetAllProductionOrderDetails/1
        [Route("GetAllProductionOrderDetails/{id}")]
        public ActionResult GetAllProductionOrderDetails(int id)
        {
            try
            {
                var lista = this.productionOrderDetailDAO.GetAllProductionOrderDetails(id);
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

        // GET: ProductionOrderDetails/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.productionOrderDetailDAO.Details(id);
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

        // POST: ProductionOrderDetails/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(ProductionOrderDetailDTO pod)
        {
            try
            {
                if (this.productionOrderDetailDAO.Add(pod))
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

        // POST: ProductionOrderDetails/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, ProductionOrderDetailDTO pod)
        {
            try
            {
                if (this.productionOrderDetailDAO.Edit(id, pod))
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

        // POST: ProductionOrderDetails/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.productionOrderDetailDAO.Remove(id))
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
