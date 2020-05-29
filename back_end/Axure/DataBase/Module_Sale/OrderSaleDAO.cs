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

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        OrderSaleDetailDAO osdDAO = new OrderSaleDetailDAO();

        public List<OrderSaleDTO> List()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var ls = db.OrderSales.Where(x => x.Deleted == false)
                        .Select(x => new { Id = x.Id, ClientId = x.ClientId, Status = x.Status, OrderNumber = x.OrderNumber, Day = x.Date.Day, Month = x.Date.Month, Year = x.Date.Year, SellerId = x.EmployeeId })
                        .ToList()
                        .Select(y => new OrderSaleDTO { Id = y.Id, ClientId = y.ClientId, Status = y.Status, OrderNumber = y.OrderNumber, Day = y.Day, Month = y.Month, Year = y.Year, EmployeeId = y.SellerId })
                        .ToList();
                        return ls;

                }
            }
            catch (Exception e)
            {
                log.Error("Error al obtener listado de ordenes List OrderSaleDAO");
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
                            .Select(x => new { Id = x.Id, ClientId = x.ClientId, Status = x.Status, EmployeeId = x.EmployeeId, OrderNumber = x.OrderNumber, Day = x.Date.Day, Month = x.Date.Month, Year = x.Date.Year })
                            .ToList()
                            .Select(y => new OrderSaleListDTO { Id = y.Id, ClientId = y.ClientId, Status = y.Status, EmployeeId = y.EmployeeId, OrderNumber = y.OrderNumber, Day = y.Day, Month = y.Month, Year = y.Year, ListDetails = osdDAO.ListByMaster(y.Id) })
                            .ToList();

                        return osR;
                }
            }
            catch (Exception e)
            {
                log.Error("Error al obtener listado de ordenes ListByClient " + e.Message + e.StackTrace);
                return null;
            }
        }
        
        //Ordenes por la cabecera
        public List<OrderSaleListDTO> ListByStatus(string status)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var os = db.OrderSales.Where(x => x.Status.Equals(status) && x.Deleted == false).ToList();
                    List<OrderSale> osList = new List<OrderSale>();
                        os.ForEach(x => osList.Add(db.OrderSales.Single(y => y.Id == x.Id)));

                        var osR = osList
                            .Select(x => new { Id = x.Id, ClientId = x.ClientId, Status = x.Status, EmployeeId = x.EmployeeId, OrderNumber = x.OrderNumber, Day = x.Date.Day, Month = x.Date.Month, Year = x.Date.Year })
                            .ToList()
                            .Select(y => new OrderSaleListDTO { Id = y.Id, ClientId = y.ClientId, Status = y.Status, EmployeeId = y.EmployeeId, OrderNumber = y.OrderNumber, Day = y.Day, Month = y.Month, Year = y.Year, ListDetails = osdDAO.ListByMaster(y.Id) })
                            .ToList();

                        return osR;
                }
            }
            catch (Exception e)
            {
                log.Error("Error al obtener listado de ordenes ListByState " + e.Message + e.StackTrace);
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
                    return new OrderSaleListDTO { Id = y.Id, ClientId = y.ClientId, Status = y.Status, EmployeeId = y.EmployeeId, OrderNumber = y.OrderNumber, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, ListDetails = osdDAO.ListByMaster(y.Id) };
                    
                }
            }
            catch (Exception e)
            {
                log.Error("Error al mostrar el listado de orden de venta por Id. " + e.Message + e.StackTrace);
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
                    OrderSale y = db.OrderSales.FirstOrDefault(x => x.OrderNumber == number && x.Deleted == false);
                        return new OrderSaleListDTO { Id = y.Id, ClientId = y.ClientId, Status = y.Status, EmployeeId = y.EmployeeId, OrderNumber = y.OrderNumber, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, ListDetails = osdDAO.ListByMaster(y.Id) };
                }
            }
            catch (Exception e)
            {
                log.Error("Error al Mostrar orden de venta por numero de orden. "+ e.Message + e.StackTrace);
                return null;
            }
        }

        public List<string> GetAllStatus()
        {
            try
            {
                List<string> status = new List<string>();
                foreach (string i in Enum.GetNames(typeof(StatusOrderSale)))
                    status.Add(i);
                return status;
            }catch(Exception e)
            {
                log.Error("Error al Mostrar los estados de una orden de venta. " + e.Message + e.StackTrace);
                return null;
            }
        }

        public bool Add(OrderSaleListDTO so)
        {

            using (var db = new AxureContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //Create the order sale.
                        OrderSale soC = new OrderSale()
                        { ClientId = so.ClientId, EmployeeId = so.EmployeeId, OrderNumber = so.OrderNumber, Date = new DateTime(so.Year, so.Month, so.Day), Status = StatusOrderSale.Pendiente.ToString(), Deleted = false };
                        db.OrderSales.Add(soC);
                        db.SaveChanges();

                        //Add details.
                        if (null != so.ListDetails)
                        {
                            for (int i = 0; i < so.ListDetails.Count; i++)
                            {
                                db.OrderSaleDetails.Add(new OrderSaleDetail() { SaleOrderId = soC.Id, ProductId = so.ListDetails[i].ProductId, Quantity = so.ListDetails[i].Quantity, QuantityPending = so.ListDetails[i].Quantity });
                            }
                        }
                        db.SaveChanges();

                        //Everything went well.
                        dbContextTransaction.Commit();
                        return true;
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        log.Error("Error al agregar orden de venta " + so.OrderNumber + " Add OrderSaleDAO");
                        return false;
                    }
                }
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
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                log.Error("No se puedo borrar la orden de venta de id "+ id + e.Message + e.StackTrace);
                return false;
            }
        }

        //cambiar estado
        public bool UpdateState(int osId, string status)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    OrderSale os = db.OrderSales.FirstOrDefault(x => x.Id == osId);
                    os.Status = status;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                log.Error("No se puede modificar el estado de la orden. " + e.Message + e.StackTrace);
                return false;
            }
        }
    }

    public enum StatusOrderSale
    {
        Pendiente,
        Procesando,
        Completado,
        Cancelado
    }
}