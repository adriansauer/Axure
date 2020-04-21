using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Stock
{
    public class ProductionStateDB
    {
        /*public ProductionStateDB()
        {
        }

        
         //Metodo ObtenerTodosProductos, retorna todos los productos que tiene registrado.
        
        public List<ProductionStateDTO> ObtenerTodosLosEstadosProduccion()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var respuesta = db.ProductionStates.Where(x => x.Delete == false)
                        .Select(x => new { Id = x.Id, StateP = x.StateP })
                        .ToList()
                        .Select(y => new ProductionStateDTO() { Id = y.Id, StateP = y.StateP})
                        .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public ProductionStateDTO DetalleDelEstadoProduccion(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var ps = db.ProductionStates.FirstOrDefault(x => x.Id == id && x.Delete == false);
                    return new ProductionStateDTO() { Id = ps.Id, StateP =ps.StateP};
                }
            }
            catch
            {
                return null;
            }

        }


        public bool Agregar(ProductionStateDTO ps)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.ProductionStates.Add(new ProductionState { StateP = ps.StateP, Delete = false });
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }


        public bool Editar(int id, ProductionStateDTO ps)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductionState psEditado = db.ProductionStates.FirstOrDefault(x => x.Id == id && x.Delete == false);
                    psEditado.StateP = ps.StateP;
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
                    ProductionState ps = db.ProductionStates.FirstOrDefault(x => x.Id == id);
                    ps.Delete = true;
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
        */
    }
}