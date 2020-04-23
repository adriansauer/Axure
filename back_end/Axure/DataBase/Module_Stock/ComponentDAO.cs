using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ComponentDAO class
 * Created april 20, 2020 by Victor Ciceia.
 */
namespace Axure.DataBase.Module_Stock
{
    public class ComponentDAO
    {

        public ComponentDAO()
        {
        }

        public List<ProductComponentDTO> GetAll()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var respuesta = db.ProductComponents
                        .Select(x => new { Id = x.Id, ProductId  = x.ProductId, ProductComponentId = x.ProductComponentId, Quantity = x.Quantity})
                        .ToList()
                        .Select(y => new ProductComponentDTO() { Id = y.Id, ProductId = y.ProductId, ProductComponentId = y.ProductComponentId, Quantity = y.Quantity})
                        .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public ComponentDTO Detail(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var comp = db.ProductComponents.FirstOrDefault(x => x.Id == id );
                    ProductDAO productDAO = new ProductDAO();
                    ProductDTO prodComp = productDAO.Detail(comp.ProductComponentId);

                    return new ComponentDTO() { Id = comp.Id, ProductId = comp.ProductId, ProductComponent = prodComp, Quantity = comp.Quantity};
                }
            }
            catch
            {
                return null;
            }

        }

        public List<ProductComponentDTO> GetComponentOfProduct(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var respuesta = db.ProductComponents.Where(x => x.ProductId == id)
                        .Select(x => new { Id = x.Id, ProductId = x.ProductId, ProductComponentId = x.ProductComponentId, Quantity = x.Quantity })
                        .ToList()
                        .Select(y => new ProductComponentDTO() { Id = y.Id, ProductId = y.ProductId, ProductComponentId = y.ProductComponentId, Quantity = y.Quantity })
                        .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool Add(ProductComponentDTO c)
        {
            try
            {
                using (var db = new AxureContext())
                {                 
                    db.ProductComponents.Add(new ProductComponent() { ProductId = c.ProductId, ProductComponentId = c.ProductComponentId, Quantity = c.Quantity});             
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Edit(int id, ProductComponentDTO pct)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductComponent pctEditado = db.ProductComponents.FirstOrDefault(x => x.Id == id);
                    pctEditado.ProductId = pct.ProductId;
                    pctEditado.ProductComponentId = pct.ProductComponentId;
                    pctEditado.Quantity = pct.Quantity;
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
                    ProductComponent pct = db.ProductComponents.Single(x => x.Id == id);
                    if (null == pct) { return true; }
                    db.ProductComponents.Remove(pct);
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