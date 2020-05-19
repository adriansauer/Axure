using Axure.DataBase.Module_Sale;
using Axure.DTO.Module_Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 * ClientsController class
 * Created May 18, 2020 by Victor Ciceia.
 */
namespace Axure.Controllers.Module_Sale
{
    [RoutePrefix("Clients")]
    public class ClientsController : Controller
    {

        private ClientDAO clientDAO;

        public ClientsController()
        {
            this.clientDAO = new ClientDAO();
        }

        // GET: Clients
        [Route("Index")]
        public ActionResult Index()
        {
            try
            {
                return Json(new { Id = "True", Name = "True", Address = "True", RUC = "True", CreditMaximum = "True", CreditPending = "True" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return new HttpStatusCodeResult(CodeHTTP.ACCEPTED);
            }
        }

        // GET: Clients/List
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.clientDAO.GetAll();
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

        // GET: Clients/Details/5
        [Route("Details/{id}")]
        public ActionResult Details(int id)
        {
            try
            {
                var dato = this.clientDAO.Detail(id);
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

        // POST: Clients/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(ClientDTO c)
        {
            try
            {
                if (this.clientDAO.Add(c))
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

        // POST: Clients/Edit/5
        [HttpPost]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id, ClientDTO e)
        {
            try
            {
                if (this.clientDAO.Edit(id, e))
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

        // POST: Clients/Delete/5
        [HttpPost]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.clientDAO.Remove(id))
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
