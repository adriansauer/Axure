using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Stock
{
    public class ProductionOrderDetailDB
    {
        public ProductionOrderDetailDB()
        {
        }

        public List<ProductionOrderDetailDTO> ObtenerTodosLosDetallesDeOrdenProduccion()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var respuesta = db.ProductionOrderDetails
                        .Select(x => new { Id = x.Id, IdProductComponent = x.IdProductComponent, IdProductionOrder = x.IdProductionOrder, Quantity = x.Quantity })
                           .ToList()
                           .Select(y => new ProductionOrderDetailDTO() { Id = y.Id, IdProductComponent = y.IdProductComponent, IdProductionOrder = y.IdProductionOrder, Quantity = y.Quantity })
                           .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public ProductionOrderDetailDTO DetalleDeDetalleDeOrdenProduccion(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var detalle = db.ProductionOrderDetails.FirstOrDefault(x => x.Id == id);
                    return new ProductionOrderDetailDTO { Id = detalle.Id, IdProductComponent = detalle.IdProductComponent, IdProductionOrder = detalle.IdProductionOrder, Quantity = detalle.Quantity };
                }
            }
            catch
            {
                return null;
            }

        }

        public List<ProductionOrderDetailDTO> ObtenerTodosLosDetallesDeUnaOrden(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var listado = db.ProductionOrderDetails.Where(x => x.IdProductionOrder == id)
                        .Select(x => new { Id = x.Id, IdProductComponent = x.IdProductComponent, IdProductionOrder = x.IdProductionOrder, Quantity = x.Quantity })
                           .ToList()
                           .Select(y => new ProductionOrderDetailDTO() { Id = y.Id, IdProductComponent = y.IdProductComponent, IdProductionOrder = y.IdProductionOrder, Quantity = y.Quantity })
                           .ToList();
                    return listado;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool Agregar(ProductionOrderDetail pod)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.ProductionOrderDetails.Add(pod);
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Editar(int id, ProductionOrderDetail pod)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrderDetail podEditado = db.ProductionOrderDetails.FirstOrDefault(x => x.Id == id);
                    podEditado.IdProductionOrder = pod.IdProductionOrder;
                    podEditado.IdProductComponent = pod.IdProductComponent;
                    podEditado.Quantity = pod.Quantity;
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }


        public bool Eliminar(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrderDetail pod = db.ProductionOrderDetails.Single(x => x.Id == id);
                    if (null == pod) { return true; }
                    db.ProductionOrderDetails.Remove(pod);
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }
    }
}