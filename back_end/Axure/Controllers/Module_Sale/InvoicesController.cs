using Axure.DataBase.Module_Sale;
using Axure.DTO.Module_Sale.InvoiceIn;
using Axure.DTO.Module_Sale.InvoicePreCreation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Sale
{
    [RoutePrefix("Invoices")]
    public class InvoicesController : Controller
    {

        private InvoiceDAO invoiceDAO;

        public InvoicesController()
        {
            invoiceDAO = new InvoiceDAO();
        }

        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.invoiceDAO.List();
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

        // GET: Invoices/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        [Route("Validate")]
        public ActionResult Validate(InvoiceInPreCreationDTO inData)
        {
            try
            {
                InvoiceOutPreCreationDTO outData = this.invoiceDAO.Validate(inData);
                if (outData != null)
                    return Json(outData, JsonRequestBehavior.AllowGet);
                else return new HttpStatusCodeResult(406);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return new HttpStatusCodeResult(406);
            }
        }

        [HttpPost]
        [Route("Create")]
        public ActionResult Create(InvoiceInDTO invoiceDTO)
        {
            try
            {
                List<int> listProduct= this.invoiceDAO.Add(invoiceDTO);
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
