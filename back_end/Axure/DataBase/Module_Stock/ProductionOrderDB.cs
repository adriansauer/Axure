using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;

namespace Axure.DataBase.Module_Stock
{
    public class ProductionOrderDB
    {

        ProductsDB productDB;

        public ProductionOrderDB()
        {
            this.productDB = new ProductsDB();
        }

        /*
         * Metodo ObtenerTodosProductos, retorna todos los productos que tiene registrado.
        */
        public List<ProductionOrderDTO> ObtenerTodasOrdenesProduccion()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrderDetailDB productionOrderDetailDB = new ProductionOrderDetailDB();
                    var opList = db.ProductionOrders.Where(x => x.Delete == false)
                           .Select(x => new { Id = x.Id, IdProductionState = x.IdProductionState, IdProduct  = x.IdProduct, IdEmployee = x.IdEmployee, DateT = x.DateT , Quantity = x.Quantity, Code = x.Code })
                           .ToList()
                           .Select(y => new ProductionOrderDTO() { Id=y.Id, IdProductionState = y.IdProductionState, IdProduct = y.IdProduct, IdEmployee = y.IdEmployee, DateT = y.DateT, Quantity = y.Quantity, Code = y.Code})
                           .ToList();
                    opList.ForEach(x => x.ListDetails = productionOrderDetailDB.ObtenerTodosLosDetallesDeUnaOrden(x.Id));
                       return opList;
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public ProductionOrderDTO DetalleOrdenProduccion(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrderDetailDB productionOrderDetailDB = new ProductionOrderDetailDB();
                    var po = db.ProductionOrders.FirstOrDefault(x => x.Id == id && x.Delete == false);
                    return new ProductionOrderDTO() { Id = po.Id, IdProductionState = po.IdProductionState, IdProduct = po.IdProduct, IdEmployee = po.IdEmployee, DateT = po.DateT, Quantity = po.Quantity, Code = po.Code, ListDetails = productionOrderDetailDB.ObtenerTodosLosDetallesDeUnaOrden(id) };
                }
            }
            catch
            {
                return null;
            }

        }

        public bool Agregar(ProductionOrderDTO orden)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrder nuevo = new ProductionOrder() { IdProductionState = orden.IdProductionState, IdProduct = orden.IdProduct, IdEmployee = orden.IdEmployee, DateT = new DateTime(2020, 03, 10), Quantity = orden.Quantity, Code = orden.Code, Delete = false };
                    db.ProductionOrders.Add(nuevo);
                    db.SaveChanges();
                    ProductionOrderDetailDB productionOrderDetailDB = new ProductionOrderDetailDB();
                    for (int i = 0; i < orden.ListDetails.Count; i++)
                    {
                        productionOrderDetailDB.Agregar(new ProductionOrderDetail() { IdProductComponent = orden.ListDetails[i].IdProductComponent, IdProductionOrder = orden.ListDetails[i].IdProductionOrder, Quantity = orden.ListDetails[i].Quantity});
                    }
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Editar(int id, ProductionOrderDTO po)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrder poEditado = db.ProductionOrders.FirstOrDefault(x => x.Id == id);
                    poEditado.IdProduct = po.IdProduct;
                    poEditado.IdProductionState = po.IdProductionState;
                    poEditado.IdEmployee = po.IdEmployee;
                    poEditado.Quantity = po.Quantity;
                    poEditado.DateT = po.DateT;
                    poEditado.Code = po.Code;
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool darDeBaja(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrder bajar = db.ProductionOrders.FirstOrDefault(x => x.Id == id);
                    bajar.Delete = true;
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
                    ProductionOrder po = db.ProductionOrders.Single(x => x.Id == id);
                    if (null == po) { return true; }
                    db.ProductionOrders.Remove(po);
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