using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    [RoutePrefix("ProductCategories")]
    public class ProductCategoriesController : Controller
    {
        private ProductCategoryDAO productCategoryDAO;

        public ProductCategoriesController()
        {
            this.productCategoryDAO = new ProductCategoryDAO();
        }

        // GET: ProductCategories/List
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.productCategoryDAO.GetAll();
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

        // GET: ProductCategories/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.productCategoryDAO.Detail(id);
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

        // GET: ProductCategories/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(ProductCategoryDTO p)
        {
            try
            {
                if (this.productCategoryDAO.Add(p))
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
        // GET: ProductCategories/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, ProductCategoryDTO e)
        {
            try
            {
                if (this.productCategoryDAO.Edit(id, e))
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
