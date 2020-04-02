using Axure.DataBase;
using Axure.DataBase.Module_Stock;
using Axure.DTO.DataBase.Module_Stock;
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
 * Controlado de Productos Danhados o Dados de Baja
 * Creado por Enzo Ramirez
 * 30-03-2020
 */
namespace Axure.Controllers.Module_Stock
{
    public class DamagedProductsController : Controller
    {

        private DamagedProductsDB damagedProductsDB;

        //Constructor
        public DamagedProductsController()
        {
            this.damagedProductsDB = new DamagedProductsDB();
        }

        // GET: DamagedProducts
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "False", DateD = "True", IdProduct = "True", Quantity = "True", Reason = "False"});
            }
            catch
            {
                return new HttpStatusCodeResult(202);
            }
            //return View();
        }

        //Get todos los productos dados de baja
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var ls = this.damagedProductsDB.TodosProductosBaja();
                if(null != ls)
                {
                    return Json(ls,JsonRequestBehavior.AllowGet);
                }
                return new HttpStatusCodeResult(202);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }
         //Get Perdida generada
         [Route("Perdida")]
         public ActionResult Perdida()
        {
            try
            {
                return Json(new { Sum = this.damagedProductsDB.Perdida()},JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.damagedProductsDB.Eliminar(id))
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

        //Post Editar un Producto dado de baja
        [HttpPut]
        [Route()]
        public ActionResult Editar(int id, DamagedProductDTO prod) 
        {
            try
            {
                if (this.damagedProductsDB.Editar(id, prod))
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
