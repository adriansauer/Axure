using Axure.DataBase;
using Axure.DataBase.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using Axure.Models.Module_Stock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 * ProductsController class
 * Created march 10, 2020 by Victor Ciceia.
 */
namespace Axure.Controllers.Module_Stock
{
<<<<<<< HEAD
=======
   // [EnableCors(origins: "*", headers: "*", methods: "*")]
>>>>>>> master
    [RoutePrefix("Products")]
    public class ProductsController : Controller
    {
        //Attributes.
        private ProductDAO productDAO;

        public ProductsController()
        {
            this.productDAO = new ProductDAO();
        }

        //[Authorize(Roles = "user, admin")]
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", ProductType = "True", Name = "True", Description = "True", Cost = "True", Quantity = "True", Barcode = "True" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
            }
        }

        // GET: Products/List
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.productDAO.GetAll();
                if(null != lista)
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

        // GET: Products/OfDeposit/1
        [Route("OfDeposit/{id}")]
        public ActionResult OfDeposit(int id)
        {
            try
            {
                var lista = this.productDAO.ProductDeposit(id);
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

        // GET: Products/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.productDAO.Detail(id);
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

        // GET: Products/SumDeposit/5
        [Route("SumDeposit/{id}")]
        public ActionResult SumDeposit(int id)
        {
            try
            {
                return Json(new { Sum = this.productDAO.SumProductPricesDeposit(id) }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }
        }

        // POST: Products/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(Pc pc)
        {
            try
            {
                if(null == pc.ListComponents)
                {
                    if(this.productDAO.Add(pc))
                        return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
                }
                else
                {
                    if(this.productDAO.AddPc(pc))
                        return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
                }
                return new HttpStatusCodeResult(CodeHTTP.OK);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }
        }

        // POST: Products/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, Product prod)
        {
            try
            {
                if (this.productDAO.Editar(id, prod))
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

        // DELETE: Products/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.productDAO.Remove(id))
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
