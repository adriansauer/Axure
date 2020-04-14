using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Stock
{
    public class ComponentDB
    {

        public ComponentDB()
        {
        }

        public List<ProductComponentDTO> ObtenerTodosLosComponentes()
        {
            try
            {
                using (var db = new AxureContext())
                {

                    var respuesta = db.ProductComponents.Where(x => x.Delete == false)
                        .Select(x => new { Id = x.Id, IdProduct  = x.IdProduct, IdProductComponent = x.IdProductComponent, Quantity = x.Quantity})
                        .ToList()
                        .Select(y => new ProductComponentDTO() { Id = y.Id, IdProduct = y.IdProduct, IdProductComponent = y.IdProductComponent, Quantity = y.Quantity})
                        .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public ComponentDTO DetalleDelComponente(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var comp = db.ProductComponents.FirstOrDefault(x => x.Id == id && x.Delete == false);
                    ProductsDB productsDB = new ProductsDB();
                    ProductDTO prod = productsDB.DetalleProducto(comp.IdProduct);
                    ProductDTO prodComp = productsDB.DetalleProducto(comp.IdProductComponent);

                    return new ComponentDTO() { Id = comp.Id, Product = prod, ProductComponent = prodComp, Quantity = comp.Quantity};
                }
            }
            catch
            {
                return null;
            }

        }

        public List<ProductComponentDTO> ObtenerTodosLosComponentesDeUnProducto(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var respuesta = db.ProductComponents.Where(x => x.IdProduct == id && x.Delete == false)
                        .Select(x => new { Id = x.Id, IdProduct = x.IdProduct, IdProductComponent = x.IdProductComponent, Quantity = x.Quantity })
                        .ToList()
                        .Select(y => new ProductComponentDTO() { Id = y.Id, IdProduct = y.IdProduct, IdProductComponent = y.IdProductComponent, Quantity = y.Quantity })
                        .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public bool Agregar(ProductComponentDTO c)
        {
            try
            {
                using (var db = new AxureContext())
                {                 
                    db.ProductComponents.Add(new ProductComponent() { IdProduct = c.IdProduct, IdProductComponent = c.IdProductComponent, Quantity = c.Quantity, Delete = false});             
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Editar(int id, ProductComponentDTO pct)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductComponent pctEditado = db.ProductComponents.FirstOrDefault(x => x.Id == id);
                    pctEditado.IdProduct = pct.IdProduct;
                    pctEditado.IdProductComponent = pct.IdProductComponent;
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

        public bool darDeBaja(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductComponent pct = db.ProductComponents.FirstOrDefault(x => x.Id == id);
                    pct.Delete = true;
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