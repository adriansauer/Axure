using Antlr.Runtime.Misc;
using Axure.DataBase.Module_Stock;
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
       /* private MovementProductDetailDAO movementDAO;

        public MovementProductDetailsController()
        {
            this.movementDAO = new MovementProductDetailDAO();
        }

        // POST: Agregar Entrada Salida de Productos
        [HttpPost]
        [Route("Agregar")]
        public ActionResult Agregar(MovementProductDetail esp)
        {
            try
            {
                if(this.movementDAO.Agregar(esp)==true) return new HttpStatusCodeResult(200);
                else return new HttpStatusCodeResult(406);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        // GET: EntSalProductDetails/Edit/5
        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, MovementProductDetail esp)
        {
            try
            {
                if (this.movementDAO.Editar(id, esp) == true) return new HttpStatusCodeResult(200);
                else return new HttpStatusCodeResult(406);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        // POST: EntSalProductDetails/Delete/5
        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                try
                {
                    if (this.movementDAO.Eliminar(id) == true) return new HttpStatusCodeResult(200);
                    else return new HttpStatusCodeResult(406);
                }
                catch
                {
                    return new HttpStatusCodeResult(406);
                }
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
                var lista = this.movementDAO.Obtener();
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

        [Route("ForMovement/{id}")]
        public ActionResult ForMovement(int id)
        {
            try
            {
                var lista = this.movementDAO.ObtenerPorNro(id);
                if (null != lista) return Json(lista, JsonRequestBehavior.AllowGet);
                return new HttpStatusCodeResult(200);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }*/
    }
}
