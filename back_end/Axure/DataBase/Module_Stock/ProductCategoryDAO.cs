using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Stock
{
    public class ProductCategoryDAO
    {
        public List<ProductCategoryDTO> GetAll()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    return db.ProductCategories.ToList().Select( x => new { Id = x.Id, Description = x.Description }).ToList().Select(y => new ProductCategoryDTO { Id = y.Id, Description = y.Description }).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public ProductCategoryDTO Detail(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductCategory pC = db.ProductCategories.FirstOrDefault(x => x.Id == id);
                    return new ProductCategoryDTO { Id = pC.Id, Description = pC.Description };
                }
            }
            catch
            {
                return null;
            }

        }

        public bool Add(ProductCategoryDTO pC)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.ProductCategories.Add(new ProductCategory { Id = pC.Id, Description = pC.Description});
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Edit(int id, ProductCategoryDTO d)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductCategory catEditado = db.ProductCategories.FirstOrDefault(x => x.Id == id);
                    catEditado.Description = d.Description;
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