using Axure.DTO.Module_Purchase;
using Axure.Models;
using Axure.Models.Module_Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Purchase
{
    public class PurchaseOrderDAO
    {
        public PurchaseOrderDAO() { }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        PurchaseOrderDetailDAO purchaseOrderDetailDAO = new PurchaseOrderDetailDAO();

        public List<PurchaseOrderDTO> List()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var ls = db.PurchaseOrders.Include("Provider")
                        .Select(x => new { Id = x.Id, Provider = x.Provider, Status = x.Status, Number = x.Number, Day = x.Date.Day, Month = x.Date.Month, Year = x.Date.Year })
                        .ToList()
                        .Select(y => new PurchaseOrderDTO { Id = y.Id, ProviderId = y.Provider.Id, ProviderName = y.Provider.Name, Status = y.Status, Number = y.Number, Day = y.Day, Month = y.Month, Year = y.Year })
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
        /*public List<PurchaseOrderDetailsDTO> ListByClient(int clId)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var os = db.OrderSales.Where(x => x.ClientId == clId).ToList();
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
        }*/
        /*
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
        }*/
        
        //orden por id
        public PurchaseOrderDetailsDTO GetById(int Id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    PurchaseOrder po = db.PurchaseOrders.Include("Provider").FirstOrDefault(x => x.Id == Id);
                    return new PurchaseOrderDetailsDTO {
                        Id = po.Id,
                        ProviderId = po.Provider.Id,
                        ProviderName = po.Provider.Name,
                        Status = po.Status,
                        Number = po.Number,
                        Day = po.Date.Day,
                        Month = po.Date.Month,
                        Year = po.Date.Year,
                        ListDetails = this.purchaseOrderDetailDAO.ListByMaster(Id)
                    };
                }
            }
            catch (Exception e)
            {
                log.Error("Error al mostrar el listado de orden de venta por Id. " + e.Message + e.StackTrace);
                return null;
            }
        }

        /*
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
                log.Error("Error al Mostrar orden de venta por numero de orden. " + e.Message + e.StackTrace);
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
            }
            catch (Exception e)
            {
                log.Error("Error al Mostrar los estados de una orden de venta. " + e.Message + e.StackTrace);
                return null;
            }
        }
        */
        public bool Add(PurchaseOrderDetailsDTO pOD)
        {
            using (var db = new AxureContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //Create the order sale.
                        PurchaseOrder pO = new PurchaseOrder(){
                            ProviderId = pOD.ProviderId,
                            Date = new DateTime(pOD.Year, pOD.Month, pOD.Day), 
                            Status = StatusOrderPurchase.Pendiente.ToString()
                        };
                        db.PurchaseOrders.Add(pO);
                        db.SaveChanges();

                        pO.Number = pO.Id;

                        //Add details.
                        if (null != pOD.ListDetails)
                        {
                            for (int i = 0; i < pOD.ListDetails.Count; i++)
                            {
                                db.PurchaseOrderDetails.Add(new PurchaseOrderDetail() { PurchaseOrderId = pO.Id, ProductId = pOD.ListDetails[i].ProductId, Quantity = pOD.ListDetails[i].Quantity, QuantityPending = pOD.ListDetails[i].Quantity, Price = pOD.ListDetails[i].Price });
                            }
                        }
                        db.SaveChanges();

                        //Everything went well.
                        dbContextTransaction.Commit();
                        return false;
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        log.Error("Error al agregar orden de compra");
                        return true;
                    }
                }
            }
        }
        /*

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

        public List<int> verificationProductQuantity(List<OrderSaleDetailDTO> listOrderDetails, List<ProductQuantityDTO> listInvoiceItems)
        {
            try
            {
                List<int> listNotExitentProducts = new List<int>();
                foreach (ProductQuantityDTO item in listInvoiceItems)
                {
                    bool exists = false;
                    foreach (OrderSaleDetailDTO orderItem in listOrderDetails)
                    {
                        if (orderItem.ProductId == item.ProductId)
                        {
                            if (orderItem.QuantityPending >= item.Quantity)
                            {
                                exists = true;
                            }
                            else
                            {
                                listNotExitentProducts.Add(item.ProductId);
                                exists = true;
                            }
                        }
                    }
                    if (!exists)
                    {
                        return null;
                    }
                }
                return listNotExitentProducts;
            }
            catch (Exception e)
            {
                log.Error("Error. No se pudo controlar la cantidad de los productos de una orden de venta" + e.Message + e.StackTrace);
                return null;
            }
        }

        public bool ModifyProductsQuantity(int idOrder, List<ProductQuantityDTO> listItems)
        {
            using (var db = new AxureContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        OrderSaleDetailDAO orderSaleDetailDAO = new OrderSaleDetailDAO();
                        List<OrderSaleDetailDTO> orderItems = orderSaleDetailDAO.ListByMaster(idOrder);
                        foreach (ProductQuantityDTO listItem in listItems)
                        {
                            foreach (OrderSaleDetailDTO orderItem in orderItems)
                            {
                                if (listItem.ProductId == orderItem.ProductId)
                                {
                                    int newQuantity = orderItem.QuantityPending - listItem.Quantity;
                                    if (newQuantity < 0)
                                    {
                                        return false;
                                    }
                                    OrderSaleDetail os = db.OrderSaleDetails.FirstOrDefault(x => x.Id == orderItem.Id);
                                    os.QuantityPending = newQuantity;
                                    db.SaveChanges();
                                }
                            }
                        }
                        //Everything went well.
                        dbContextTransaction.Commit();

                        if (CheckStatusProcess(idOrder))
                        {
                            throw new System.Exception();
                        }
                        return true;
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        log.Error("Error al agregar una factura!!!");
                        return false;
                    }
                }
            }
        }

        private bool CheckStatusProcess(int idOrder)
        {
            using (var db = new AxureContext())
            {
                try
                {
                    OrderSaleDetailDAO orderSaleDetailDAO = new OrderSaleDetailDAO();
                    List<OrderSaleDetailDTO> orderItems = orderSaleDetailDAO.ListByMaster(idOrder);
                    foreach (OrderSaleDetailDTO orderItem in orderItems)
                    {
                        if (orderItem.QuantityPending > 0)
                        {
                            UpdateState(idOrder, StatusOrderSale.Procesando.ToString());
                            return false;
                        }
                    }
                    UpdateState(idOrder, StatusOrderSale.Completado.ToString());
                    return false;
                }
                catch (Exception e)
                {
                    return true;
                }
            }
        }*/
    }

    public enum StatusOrderPurchase
    {
        Pendiente,
        Procesando,
        Completado,
        Cancelado
    }
}