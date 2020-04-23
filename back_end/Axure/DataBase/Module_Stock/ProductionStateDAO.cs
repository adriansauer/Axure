using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ProductionStateDAO class
 * Created april 20, 2020 by Victor Ciceia.
 */
namespace Axure.DataBase.Module_Stock
{
    public class ProductionStateDAO
    {
        public ProductionStateDAO()
        {
        }
        
        public List<ProductionStateDTO> GetAll()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var respuesta = db.ProductionStates.Where(x => x.Deleted == false)
                        .Select(x => new { Id = x.Id, State = x.State })
                        .ToList()
                        .Select(y => new ProductionStateDTO() { Id = y.Id, State = y.State})
                        .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public ProductionStateDTO Detail(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var ps = db.ProductionStates.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    return new ProductionStateDTO() { Id = ps.Id, State =ps.State};
                }
            }
            catch
            {
                return null;
            }

        }

        public bool Add(ProductionStateDTO ps)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.ProductionStates.Add(new ProductionState { State = ps.State, Deleted = false });
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Edit(int id, ProductionStateDTO ps)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionState psEditado = db.ProductionStates.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    psEditado.State = ps.State;
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
                    ProductionState ps = db.ProductionStates.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    ps.Deleted = true;
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
                    ProductionState ps = db.ProductionStates.Single(x => x.Id == id);
                    if (null == ps) { return true; }
                    db.ProductionStates.Remove(ps);
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