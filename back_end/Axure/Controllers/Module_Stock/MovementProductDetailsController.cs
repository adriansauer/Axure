using Antlr.Runtime.Misc;
using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using Axure.Models.Module_Stock;
using System;//
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 * Controlador Creado por Enzo Ramirez
 * 09/04/2020
 */

namespace Axure.Controllers.Module_Stock
{
    [RoutePrefix("MovementProductDetails")]
    public class MovementProductDetailsController : Controller
    {
        private MovementProductDetailDAO movementDAO;

        public MovementProductDetailsController()
        {
            this.movementDAO = new MovementProductDetailDAO();
        }

        // POST: Agregar Entrada Salida de Productos
        [HttpPost]
        [Route("Add")]
        public ActionResult Add(MovementProductDetailDTO esp)
        {
            try
            {
                if (this.movementDAO.Add(esp)) return new HttpStatusCodeResult(200);
                else return new HttpStatusCodeResult(406);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.movementDAO.List();
                if (null != lista)
                {
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
                return new HttpStatusCodeResult(200);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        [Route("byMovement/{id}")]
        public ActionResult byMovement(int id)
        {
            try
            {
                var lista = this.movementDAO.ListByMaster(id);
                if (null != lista) return Json(lista, JsonRequestBehavior.AllowGet);
                return new HttpStatusCodeResult(200);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }
    }
}
