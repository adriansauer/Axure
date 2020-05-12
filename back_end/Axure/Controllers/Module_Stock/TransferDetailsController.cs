using Axure.DataBase.Module_Stock;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Stock
{
    [RoutePrefix("TransferDetails")]
    public class TransferDetailsController : Controller
    {
        private TransferDetailDAO transferDAO;

        public TransferDetailsController()
        {
            this.transferDAO = new TransferDetailDAO();
        }

        // POST: Agregar Transferencia
        [HttpPost]
        [Route("Add")]
        public ActionResult Add(TransferDetail esp)
        {
            try
            {
                if (this.transferDAO.Add(esp) == true) return new HttpStatusCodeResult(200);
                else return new HttpStatusCodeResult(406);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }



        [Route("ListDetailOfTransfer/{id}")]
        public ActionResult ListDetailOfTransfer(int id)
        {
            try
            {
                var lista = this.transferDAO.ListDetailOfTransfer(id);
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
