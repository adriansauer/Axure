﻿using Axure.DataBase.Module_Sale;
using Axure.DTO.Module_Sale;
using Axure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Axure.Controllers.Module_Sale
{
    [RoutePrefix("OrderSales")]
    public class OrderSalesController : Controller
    {

        private OrderSaleDAO osDAO;

        public OrderSalesController()
        {
            this.osDAO = new OrderSaleDAO();
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult Add(OrderSaleListDTO os)
        {
            try
            {
                if (this.osDAO.Add(os) == true) return new HttpStatusCodeResult(200);
                else return new HttpStatusCodeResult(406);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return new HttpStatusCodeResult(406);
            }
        }

        [HttpGet]
        [Route("List")]
        public ActionResult List()
        {
            try
            {
                var lista = this.osDAO.List();
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

        //por cliente
        [HttpGet]
        [Route("ListByClient/{id}")]
        public ActionResult ListByClient(int id)
        {
            try
            {
                var lista = this.osDAO.ListByClient(id);
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

        //por estado
        [HttpGet]
        [Route("ListByState/{id}")]
        public ActionResult ListByState(int id)
        {
            try
            {
                var lista = this.osDAO.ListByState(id);
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

        //por numero
        [HttpGet]
        [Route("GetByNumber/{number}")]
        public ActionResult GetByNumber(String number)
        {
            try
            {
                var lista = this.osDAO.GetByNumber(number);
                if (null != lista)
                {
                    return Json(lista, JsonRequestBehavior.AllowGet);
                    return new HttpStatusCodeResult(200);
                }
                else
                {

                    return new HttpStatusCodeResult(406);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return new HttpStatusCodeResult(406);
            }
        }

        //por id
        [HttpGet]
        [Route("GetById/{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                var lista = this.osDAO.GetById(id);
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

       /*[HttpPut]
        [Route("UpdateState")]
        public ActionResult UpdateState(int osId, int stId)
        {
            try
            {
                if (this.osDAO.UpdateState(osId, stId) == true) return new HttpStatusCodeResult(200);
                else return new HttpStatusCodeResult(406);
            }
            catch
            {
                return new HttpStatusCodeResult(406);
            }
        }*/

        [HttpDelete]
        [Route("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                if (this.osDAO.Remove(id))
                {
                    return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
                }
                else
                {
                    return new HttpStatusCodeResult(CodeHTTP.OK);
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return new HttpStatusCodeResult(CodeHTTP.NOTACCEPTABLE);
            }
        }
    }
}
