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
    [RoutePrefix("EntSalProductDetails")]
    public class EntSalProductDetailsController : Controller
    {
        private EntSalProductDetailDAO entSalDAO;

        public EntSalProductDetailsController()
        {
            this.entSalDAO = new EntSalProductDetailDAO();
        }

        // POST: Agregar Entrada Salida de Productos
        [HttpPost]
        [Route("Agregar")]
        public ActionResult Agregar(EntSalProductDetail esp)
        {
            try
            {
                if(this.entSalDAO.Agregar(esp)==true) return new HttpStatusCodeResult(200);
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
        public ActionResult Edit(int id, EntSalProductDetail esp)
        {
            try
            {
                if (this.entSalDAO.Editar(id, esp) == true) return new HttpStatusCodeResult(200);
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
                    if (this.entSalDAO.Eliminar(id) == true) return new HttpStatusCodeResult(200);
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
                var lista = this.entSalDAO.Obtener();
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

        [Route("PorEntSal/{id}")]
        public ActionResult PorEntSal(int id)
        {
            try
            {
                var lista = this.entSalDAO.ObtenerPorNro(id);
                if (null != lista) return Json(lista, JsonRequestBehavior.AllowGet);
                return new HttpStatusCodeResult(202);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }
    }
}
