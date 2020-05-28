using Axure.DTO.Module_Sale;
using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Sale;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Sale
{
    public class OrderSaleDetailDAO
    {
<<<<<<< HEAD
        public bool Add(OrderSaleDetailDTO sod)//,AxureContext db)
        {
            try
            {
                using (var db =new AxureContext())
                {
                    db.OrderSaleDetails.Add(new OrderSaleDetail {SaleOrderId=sod.OrderSaleId, ProductId = sod.ProductId, Quantity = sod.Quantity, QuantityPending = 0, Deleted = false });
=======
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool Add(OrderSaleDetailDTO sod)//, AxureContext db)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.OrderSaleDetails.Add(new OrderSaleDetail() {SaleOrderId = sod.OrderSaleId, ProductId = sod.ProductId, Quantity = sod.Quantity, QuantityPending = 0, Deleted = false });
>>>>>>> master
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                log.Error("Error al agregar detalle de la orden con Id "+ sod.OrderSaleId +" OrderSaleDetailDAO"+ e.Message + e.StackTrace);
                return false;
            }
        }

        public List<OrderSaleDetailDTO> ListByMaster(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Product pd = db.Products.SingleOrDefault(x => x.Id == id);
                    var lista = db.OrderSaleDetails.Where(x => x.SaleOrderId == id)
                        .Select(x => new
                        {
                            Id = x.Id,
                            OrderSaleId = x.SaleOrderId,
                            ProductId = x.ProductId,
                            Quantity = x.Quantity,
                            QuantityPending = x.QuantityPending
                        })
                        .ToList()
                        .Select(y => new OrderSaleDetailDTO()
                        {
                            Id = y.Id,
                            OrderSaleId = y.OrderSaleId,
                            ProductId = y.ProductId,
                            Quantity = y.Quantity,
                            QuantityPending = y.QuantityPending
                        })
                        .ToList();
                        return lista;
                }
            }
            catch (Exception e)
            {
                log.Error("Error al obtener listado de detalles de Ordenes de venta OrderSaleDetailDAO" + e.Message + e.StackTrace);
                return null;
            }
        }

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
                log.Error("Error al actualizar la cantidad de articulos en el detalle de la orden de venta con Id "+ osId +" OrderSaleDetailDAO" + e.Message + e.StackTrace);
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
        }

        //borrado ocioso
        public bool Remove(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    OrderSaleDetail bajar = db.OrderSaleDetails.FirstOrDefault(x => x.Id == id);
                    bajar.Deleted = true;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                log.Error("Error al remover el detalle de la orden de venta con Id " + id +" OrderSaleDetailDAO" + e.Message + e.StackTrace);
                return false;
            }
        }
    }
}