using Antlr.Runtime.Misc;
using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
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
        private MovementProductDAO mvDAO;

        public MovementProductsController()
        {
            this.mvDAO = new MovementProductDAO();
        }

        // POST: MovementProducts/Agregar
        [HttpPost]
        [Route("Add")]
        public ActionResult Add(MovementProductListDTO esp)
        {
            try
            {
                if (this.mvDAO.Add(esp) == true) return new HttpStatusCodeResult(200);
                else return new HttpStatusCodeResult(406);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        /*//Todas las cabeceras de los movimientos, por deposito
        [Route("MovementByDeposit/{id}")]
        public ActionResult MovementByDeposit(int id)
        {
            try
            {
                var lista = this.mvDAO.MovementByDeposit(id);
                if (lista != null)
                    return Json(lista, JsonRequestBehavior.AllowGet);
                return new HttpStatusCodeResult(202);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }*/

        //Lista todos los movimientos
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.mvDAO.List();
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

        //Listar por id
        [Route("ListByMasterId/{id}")]
        public ActionResult ListByMasterId(int id)
        {
            try
            {
                var mv = this.mvDAO.ListByMasterId(id);
                if (null != mv) return Json(mv, JsonRequestBehavior.AllowGet);
                return new HttpStatusCodeResult(200);

            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        //Listar por motivo de movimiento
        [Route("ListByMovementMotive/{id}")]
        public ActionResult ListByMovementMotive(int id)
        {
            try
            {
                var mvList = this.mvDAO.ListByMovementMotive(id);
                if (null != mvList) return Json(mvList,JsonRequestBehavior.AllowGet);
                return new HttpStatusCodeResult(200);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        //Listar por tipo de movimiento
        [Route("ListByMovementType/{id}")]
        public ActionResult ListByMovementType(int id)
        {
            try
            {
                var mvList = this.mvDAO.ListByMovementType(id);
                if (null != mvList) return Json(mvList, JsonRequestBehavior.AllowGet);
                return new HttpStatusCodeResult(200);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }
    }
}

