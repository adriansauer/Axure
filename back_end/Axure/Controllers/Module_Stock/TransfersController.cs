using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    [RoutePrefix("Transfers")]
    public class TransfersController : Controller
    {
        private TransferDAO trDAO;

        public TransfersController()
        {
            this.trDAO = new TransferDAO();
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(Transfer tr)
        {
            try
            {
                if (this.trDAO.Add(tr) == true) return new HttpStatusCodeResult(200);
                else return new HttpStatusCodeResult(406);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }

        //listar todas las transfrencias
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.trDAO.ListAll();
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

        //Listar por numero de Transferencia
        [Route("ListMasterId/{id}")]
        public ActionResult ListMasterId(int id)
        {
            try
            {
                var lista = this.trDAO.ListMasterId(id);
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

        //Listar por deposito de origen
        [Route("ListDepositOrigin/{id}")]
        public ActionResult ListDepositOrigin(int id)
        {
            try
            {
                var lista = this.trDAO.ListDepositOrigin(id);
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

        //Listar por deposito de destino
        [Route("ListDepositDestination/{id}")]
        public ActionResult ListDepositDestination(int id)
        {
            try
            {
                var lista = this.trDAO.ListDepositDestination(id);
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
    }
}
