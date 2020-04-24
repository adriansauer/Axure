using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;

/*
 * ProductTypesController class
 * Created april 21, 2020 by Victor Ciceia.
 */
namespace Axure.Controllers.Module_Stock
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("ProductTypes")]
    public class ProductTypesController : Controller
    {

        private ProductTypeDAO productTypeDAO;

        public ProductTypesController()
        {
            this.productTypeDAO = new ProductTypeDAO();
        }

        // GET: ProductTypes
        //[Authorize(Roles = "user, admin")]
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", Type = "True"}, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
            }
        }

        // GET: Todos los tipos de productos existentes.
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.productTypeDAO.GetAll();
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

        // GET: ProductTypes/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.productTypeDAO.Detail(id);
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

        // POST: ProductTypes/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(ProductTypeDTO pt)
        {
            try
            {
                if (this.productTypeDAO.Add(pt))
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

        // POST: ProductTypes/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, ProductType pt)
        {
            try
            {
                if (this.productTypeDAO.Edit(id, pt))
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

        // POST: ProductTypes/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.productTypeDAO.Remove(id))
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
