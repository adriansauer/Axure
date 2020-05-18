using Axure.DTO.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Sale
{
    public class OrderSaleDetailDAO
    {
        /*
        public ProductionOrderDetailDAO()
        {
        }

        public List<ProductionOrderDetailDTO> GetAll()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var respuesta = db.ProductionOrderDetails.Where(x => x.Deleted == false)
                        .Select(x => new { Id = x.Id, ProductionOrderId = x.ProductionOrderId, ProductId = x.ProductId, Quantity = x.Quantity })
                        .ToList()
                        .Select(y => new ProductionOrderDetailDTO() { Id = y.Id, ProductionOrderId = y.ProductionOrderId, ProductId = y.ProductId, Quantity = y.Quantity })
                        .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public ProductionOrderDetailReportDTO Details(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var detalle = db.ProductionOrderDetails.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    ProductDAO productDAO = new ProductDAO();
                    ProductDTO productDTO = productDAO.Detail(detalle.ProductId);
                    return new ProductionOrderDetailReportDTO { Id = detalle.Id, ProductionOrderId = detalle.ProductionOrderId, Product = productDTO, Quantity = detalle.Quantity };
                }
            }
            catch
            {
                return null;
            }

        }

        public List<ProductionOrderDetailDTO> GetAllProductionOrderDetails(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var listado = db.ProductionOrderDetails.Where(x => x.ProductionOrderId == id && x.Deleted == false)
                        .Select(x => new { Id = x.Id, ProductionOrderId = x.ProductionOrderId, ProductId = x.ProductId, Quantity = x.Quantity })
                        .ToList()
                        .Select(y => new ProductionOrderDetailDTO() { Id = y.Id, ProductionOrderId = y.ProductionOrderId, ProductId = y.ProductId, Quantity = y.Quantity })
                        .ToList();
                    return listado;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool Add(ProductionOrderDetailDTO pod)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.ProductionOrderDetails.Add(new ProductionOrderDetail { ProductionOrderId = pod.ProductionOrderId, ProductId = pod.ProductId, Quantity = pod.Quantity, Deleted = false });
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Edit(int id, ProductionOrderDetailDTO pod)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrderDetail podEditado = db.ProductionOrderDetails.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    podEditado.ProductionOrderId = pod.ProductionOrderId;
                    podEditado.ProductId = pod.ProductId;
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

        public bool Remove(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionOrderDetail podEditado = db.ProductionOrderDetails.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    podEditado.Deleted = true;
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }


        public bool Delete(int id)
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
        }*/
    }
}