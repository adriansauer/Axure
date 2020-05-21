using Axure.DTO.Module_Sale;
using Axure.Models;
using Axure.Models.Module_Sale;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Sale
{
    public class OrderSaleDAO
    {
        public OrderSaleDAO() { }

        OrderSaleDetailDAO osdDAO = new OrderSaleDetailDAO();

        public bool Add(OrderSaleListDTO so) //recibe la lista detalles, 
        {
            try//investigar sobre find --- log net
            {
                using (var db = new AxureContext())
                {
                    var state = db.Settings.SingleOrDefault(x => x.Key == "ID_PRODUCTION_STATE_PENDING");
                    OrderSale soC = new OrderSale()
                    {
                        ClientId = so.ClientId,
                        StateOrderSaleId = int.Parse(state.Value),
                        OrderNumber = so.OrderNumber,
                        Date = new DateTime(so.Year, so.Month, so.Day),
                        EmployeeId = so.EmployeeId,
                        Deleted = false
                    };

                    db.OrderSales.Add(soC);
                    db.SaveChanges();

                    OrderSaleDetailDAO soD = new OrderSaleDetailDAO();

                    if (null != so.ListDetails)
                    {
                        for (int i = 0; i < so.ListDetails.Count; i++)
                        {
                            so.ListDetails[i].OrderSaleId = soC.Id;
                            soD.Add(so.ListDetails[i],db);
                        }
                    }
                    return true;
                }
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
        }

        public List<OrderSaleDTO> List()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var ls = db.OrderSales.Where(x => x.Deleted == false)
                        .Select(x => new { Id = x.Id, ClientId = x.ClientId, StateOrderSaleId = x.StateOrderSaleId, OrderNumber = x.OrderNumber, Day = x.Date.Day, Month = x.Date.Month, Year = x.Date.Year, SellerId = x.EmployeeId, Deleted = x.Deleted })
                        .ToList()
                        .Select(y => new OrderSaleDTO { Id = y.Id, ClientId = y.ClientId, StateOrderSaleId = y.StateOrderSaleId, OrderNumber = y.OrderNumber, Day = y.Day, Month = y.Month, Year = y.Year, EmployeeId = y.SellerId })
                        .ToList();
                    return ls;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }

        //Ordenes por cliente
        public List<OrderSaleListDTO> ListByClient(int clId)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var os = db.OrderSales.Where(x => x.ClientId == clId && x.Deleted == false).ToList();
                    List<OrderSale> osList = new List<OrderSale>();
                    os.ForEach(x => osList.Add(db.OrderSales.Single(y => y.Id == x.Id)));
                    var osR = osList
                        .Select(x => new { Id = x.Id, ClientId = x.ClientId, StateOrderSaleId = x.StateOrderSaleId, EmployeeId = x.EmployeeId, OrderNumber = x.OrderNumber, Day = x.Date.Day, Month = x.Date.Month, Year = x.Date.Year })
                        .ToList()
                        .Select(y => new OrderSaleListDTO { Id = y.Id, ClientId = y.ClientId, StateOrderSaleId = y.StateOrderSaleId, EmployeeId = y.EmployeeId, OrderNumber = y.OrderNumber, Day = y.Day, Month = y.Month, Year = y.Year, ListDetails = osdDAO.ListByMaster(y.Id) })
                        .ToList();

                    return osR;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }

        //Ordenes por la cabecera
        public List<OrderSaleListDTO> ListByState(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var os = db.OrderSales.Where(x => x.StateOrderSaleId == id && x.Deleted == false).ToList();
                    List<OrderSale> osList = new List<OrderSale>();
                    os.ForEach(x => osList.Add(db.OrderSales.Single(y => y.Id == x.Id)));

                    var osR = osList
                        .Select(x => new { Id = x.Id, ClientId = x.ClientId, StateOrderSaleId = x.StateOrderSaleId, EmployeeId = x.EmployeeId, OrderNumber = x.OrderNumber, Day = x.Date.Day, Month = x.Date.Month, Year = x.Date.Year })
                        .ToList()
                        .Select(y => new OrderSaleListDTO { Id = y.Id, ClientId = y.ClientId, StateOrderSaleId = y.StateOrderSaleId, EmployeeId = y.EmployeeId, OrderNumber = y.OrderNumber, Day = y.Day, Month = y.Month, Year = y.Year, ListDetails = osdDAO.ListByMaster(y.Id) })
                        .ToList();

                    return osR;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }

        //orden por id
        public OrderSaleListDTO GetById(int Id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    OrderSale y = db.OrderSales.Find(Id);// Single(x => x.Id == Id && x.Deleted == false);
                    return new OrderSaleListDTO { Id = y.Id, ClientId = y.ClientId, StateOrderSaleId = y.StateOrderSaleId, EmployeeId = y.EmployeeId, OrderNumber = y.OrderNumber, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, ListDetails = osdDAO.ListByMaster(y.Id) };
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
        }

        //orden por numero de orden
        public OrderSaleListDTO GetByNumber(string number)
        {
            try
            {
                using (var db = new AxureContext())
                {//preguntar por este comparacion entre cadenas de string
                    OrderSale y = db.OrderSales.Find(1,number);// .Single(x => x.OrderNumber.Equals(number) && x.Deleted == false);
                    return new OrderSaleListDTO { Id = y.Id, ClientId = y.ClientId, StateOrderSaleId = y.StateOrderSaleId, EmployeeId = y.EmployeeId, OrderNumber = y.OrderNumber, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, ListDetails = osdDAO.ListByMaster(y.Id) };
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                //throw new Exception(e.Message);
                return null;
            }
        }

        //borrado ocioso
        public bool Remove(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    OrderSale bajar = db.OrderSales.FirstOrDefault(x => x.Id == id);
                    bajar.Deleted = true;
                    var osD = db.OrderSaleDetails.Where(x => x.SaleOrderId == id && x.Deleted == false).ToList();

                    for (int i = 0; i < osD.Count; i++)
                    {
                        osD[i].Deleted = true;
                    }

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
        }

        //cambiar estado
        public bool UpdateState(int osId, int stId)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    OrderSale os = db.OrderSales.FirstOrDefault(x => x.Id == osId);
                    os.StateOrderSaleId = stId;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return false;
            }
        }
    }
}