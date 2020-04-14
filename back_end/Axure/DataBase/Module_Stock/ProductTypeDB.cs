using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Stock
{
    public class ProductTypeDB
    {
   
        public ProductTypeDB()
        {
        }

        /*
         * Metodo ObtenerTodosProductos, retorna todos los productos que tiene registrado.
        */
        public List<ProductTypeDTO> ObtenerTodosTiposProductos()
        {
            try
            {
                using (var db = new AxureContext())
                {

                    var respuesta = db.ProductTypes.Where(x => x.Delete == false)
                        .Select(x => new { Id = x.Id, TypeP = x.TypeP})
                        .ToList()
                        .Select(y => new ProductTypeDTO() { Id = y.Id, TypeP = y.TypeP })
                        .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public ProductTypeDTO DetalleTipoProducto(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var pt = db.ProductTypes.FirstOrDefault(x => x.Id == id && x.Delete == false);

                    return new ProductTypeDTO() { Id = pt.Id, TypeP = pt.TypeP};
                }
            }
            catch
            {
                return null;
            }

        }


        public bool Agregar(ProductTypeDTO pt)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.ProductTypes.Add(new ProductType() { TypeP = pt.TypeP, Delete = false});
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }


        public bool Editar(int id, ProductType pt)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    ProductType ptEditado = db.ProductTypes.FirstOrDefault(x => x.Id == id);
                    ptEditado.TypeP = pt.TypeP;
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
                    ProductType pt = db.ProductTypes.FirstOrDefault(x => x.Id == id);
                    pt.Delete = true;
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
        }
    }
}