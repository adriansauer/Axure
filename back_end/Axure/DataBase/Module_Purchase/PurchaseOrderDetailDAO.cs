using Axure.DTO.Module_Purchase;
using Axure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Purchase
{
    public class PurchaseOrderDetailDAO
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /*public bool Add(OrderSaleDetailDTO sod)//, AxureContext db)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.OrderSaleDetails.Add(new OrderSaleDetail() { SaleOrderId = sod.OrderSaleId, ProductId = sod.ProductId, Quantity = sod.Quantity, QuantityPending = 0 });
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                log.Error("Error al agregar detalle de la orden con Id " + sod.OrderSaleId + " OrderSaleDetailDAO" + e.Message + e.StackTrace);
                return false;
            }
        }
        */
        public List<PurchaseOrderDetailDTO> ListByMaster(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var ls = db.PurchaseOrderDetails.Include("Provider").Where(x => x.PurchaseOrderId == id)
                       .Select(x => new { Id = x.Id, Product = x.Product, Quantity = x.Quantity, QuantityPending = x.QuantityPending, Price = x.Price })
                       .ToList()
                       .Select(y => new PurchaseOrderDetailDTO { Id = y.Id, ProductId = y.Product.Id, ProductName = y.Product.Name, Quantity = y.Quantity, QuantityPending = y.QuantityPending, Price = y.Price })
                       .ToList();
                    return ls;
                }
            }
            catch (Exception e)
            {
                log.Error("Error al obtener listado de detalles de Ordenes de venta OrderSaleDetailDAO" + e.Message + e.StackTrace);
                return null;
            }
        }

        /*
        //cambiar cantidad
        public bool UpdateQuantity(int osId, int qt)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    OrderSaleDetail os = db.OrderSaleDetails.FirstOrDefault(x => x.Id == osId);
                    os.Quantity = qt;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                log.Error("Error al actualizar la cantidad de articulos en el detalle de la orden de venta con Id " + osId + " OrderSaleDetailDAO" + e.Message + e.StackTrace);
                return false;
            }
        }

        //cambiar cantidad pendiente
        public bool UpdateQuantityPending(int osId, int qt)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    OrderSaleDetail os = db.OrderSaleDetails.FirstOrDefault(x => x.Id == osId);
                    os.QuantityPending = qt;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                log.Error("Error al actualizar la cantidad pendiente de articulos en el detalle de la orden de venta con Id " + osId + " OrderSaleDetailDAO" + e.Message + e.StackTrace);
                return false;
            }
        }*/
    }
}