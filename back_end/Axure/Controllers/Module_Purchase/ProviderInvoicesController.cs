using Axure.DataBase.Module_Purchase;
using Axure.DTO.Module_Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Purchase
{
    [RoutePrefix("ProviderInvoices")]
    public class ProviderInvoicesController : Controller
    {
        private ProviderInvoiceDAO providerInvoiceDAO;

        public ProviderInvoicesController()
        {
            this.providerInvoiceDAO = new ProviderInvoiceDAO();
        }

        // GET: ProviderInvoices
        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.providerInvoiceDAO.List();
                if (null != lista)
                {
                    return Json(lista, JsonRequestBehavior.AllowGet);
                }
                return new HttpStatusCodeResult(200);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return new HttpStatusCodeResult(406);
            }
        }

        // GET: ProviderInvoices/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // POST: ProviderInvoices/Create
        [HttpPost]
        [Route("Create")]
        public ActionResult Create(PurchaseInvoiceDetailsDTO PurchaseInvoiceDetails)
        {
            try
            {
                List<int> listProduct = this.providerInvoiceDAO.Add(PurchaseInvoiceDetails);
                if (listProduct.Count != null)
                    return Json(listProduct, JsonRequestBehavior.AllowGet);
                else return new HttpStatusCodeResult(406);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return new HttpStatusCodeResult(406);
            }
        }
    }
}
