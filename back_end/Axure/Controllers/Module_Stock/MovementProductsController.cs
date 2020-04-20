using Antlr.Runtime.Misc;
using Axure.DataBase.Module_Stock;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

/*
 *Craeado por Enzo Ramirez 
 * 09/04/2020
 */

namespace Axure.Controllers.Module_Stock
{
    [RoutePrefix("MovementProducts")]
    public class MovementProductsController : Controller
    {
        private MovementProductDAO espDAO;

        public MovementProductsController()
        {
            this.espDAO = new MovementProductDAO();
        }

        // POST: MovementProducts/Agregar
        [HttpPost]
        [Route("Agregar")]
        public ActionResult Agregar(MovementProductionType esp)
        {
            try
            {
                if (this.espDAO.Agregar(esp) == true) return new HttpStatusCodeResult(200);
                else return new HttpStatusCodeResult(406);
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
                if (this.espDAO.Eliminar(id) == true) return new HttpStatusCodeResult(200);
                else return new HttpStatusCodeResult(406);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        [HttpPut]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, MovementProductionType esp)
        {
            try
            {
                if (this.espDAO.Editar(id, esp) == true) return new HttpStatusCodeResult(200);
                else return new HttpStatusCodeResult(406);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        //Todas las cabeceras de Entrada y Salida por deposito
        [Route("MovementDeposito/{id}")]
        public ActionResult MovementDeposito(int id)
        {
            try
            {
                var lista = this.espDAO.MovementDeposito(id);
                if (lista != null)
                    return Json(lista, JsonRequestBehavior.AllowGet);
                return new HttpStatusCodeResult(202);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }
    }
}
