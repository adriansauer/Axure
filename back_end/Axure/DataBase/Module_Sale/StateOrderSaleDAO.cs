using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Sale
{
    public class StateOrderSaleDAO
    {
        /*
        public ProductTypeDAO()
        {
        }

        public List<ProductTypeDTO> GetAll()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var respuesta = db.ProductTypes.Where(x => x.Deleted == false)
                        .Select(x => new { Id = x.Id, Type = x.Type })
                        .ToList()
                        .Select(y => new ProductTypeDTO() { Id = y.Id, Type = y.Type })
                        .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public ProductTypeDTO Detail(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var pt = db.ProductTypes.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    return new ProductTypeDTO() { Id = pt.Id, Type = pt.Type };
                }
            }
            catch
            {
                return null;
            }
        }

        public bool Add(ProductTypeDTO pt)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.ProductTypes.Add(new ProductType() { Type = pt.Type, Deleted = false });
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Edit(int id, ProductType pt)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductType ptEditado = db.ProductTypes.FirstOrDefault(x => x.Id == id);
                    ptEditado.Type = pt.Type;
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
                    ProductType pt = db.ProductTypes.FirstOrDefault(x => x.Id == id);
                    pt.Deleted = true;
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
                    ProductType pt = db.ProductTypes.Single(x => x.Id == id);
                    if (null == pt) { return true; }
                    db.ProductTypes.Remove(pt);
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