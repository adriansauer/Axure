using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * Creado por Enzo Ramirez 
 * 31-03-2020
 * Clase para peticiones a la BD
 */
namespace Axure.DTO.DataBase.Module_Stock
{
    public class DamagedProductsDB
    {
        ComponentDB componentDB;
        ProductsDB productsDB;

        public DamagedProductsDB()
        {
            this.componentDB = new ComponentDB();
        }
        
        //Retorna todos los Productos dados de baja '
        public List<DamagedProduct> TodosProductosBaja()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var producto = db.DamagedProducts.Where(x => x.Quantity > 0)
                        .Select(x => new { Id = x.Id, DateD = x.DateD, IdProduct = x.IdProduct, Quantity = x.Quantity, Reason = x.Reason})
                        .ToList()
                        .Select(y => new DamagedProduct() { Id = y.Id, DateD = y.DateD, IdProduct = y.IdProduct, Quantity = y.Quantity, Reason = y.Reason })
                        .ToList();
                    return producto;
                }
            }
            catch
            {
                return null;
            }
        }

        //Suma de los precio de los productos danhados PERDIDA
        public int Perdida()
        {
            int suma = 0;
            using (var db = new AxureContext())
            {
                try
                {
                    suma = db.DamagedProducts.Include("Products").Where(x => x.Quantity > 0).Sum(y => y.Product.Cost * y.Quantity);
                    return suma;
                }
                catch
                {
                    return suma;
                }
            }
        }

        //Dar de Baja un Producto
        public bool DarDeBaja(Product producto,int idDep, int cant, string motivo)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.DamagedProducts.Add(new DamagedProduct() { DateD = System.DateTime.Today, IdProduct = producto.Id, Quantity = cant, Reason = motivo});
                    Stock stock = db.Stocks.FirstOrDefault(x => x.Id == idDep);
                    //implementar descuento del stock
                    if (stock.IdProduct == producto.Id && stock.Quantity >=cant)
                    {
                        
                    }
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return true;
            }
        }

        //Sacar un producto de baja
        public bool Eliminar(int id)
        {
            try
            {
                using(var db = new AxureContext())
                {
                    DamagedProduct prod = db.DamagedProducts.Single(x => x.Id == id);
                    if(null == prod)
                    {
                        return true;
                    }
                    db.DamagedProducts.Remove(prod);
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        //Editar un producto dado de baja
        public bool Editar(int id,DamagedProductDTO DProducto)
        {
            using (var db = new AxureContext())
            {
                try
                {
                    DamagedProduct DaPro = db.DamagedProducts.FirstOrDefault(x => x.Id == id);
                    DaPro.IdProduct = DProducto.IdProduct;
                    DaPro.DateD = DProducto.DateD;
                    DaPro.Quantity = DProducto.Quantity;
                    DaPro.Reason = DProducto.Reason;
                    db.SaveChanges();
                    return true;

                }
                catch
                {
                    return true;
                }
            }
        }
    }
}