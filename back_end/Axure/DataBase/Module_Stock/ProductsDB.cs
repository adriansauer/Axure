using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*
 * Clase  ProductsDB
 * Creado el 10-03-2020 por Victor Ciceia.
 * Clase encargada de realizar peticiones a la base de datos enfocado a los productos.
 */
namespace Axure.DTO.Module_Stock
{
    public class ProductsDB
    {
        /*
         * Metodo ObtenerTodosProductos, retorna todos los productos que tiene registrado.
        */
        public List<Product> ObtenerTodosProductos()
        {
            using(var db = new AxureContext())
            {
                var respuesta = db.Products.Where(x => x.Delete == false)
                    .Select(x => new {Id= x.Id, Nombre = x.NameP, Description =x.DescriptionP, Costo = x.Cost, CantidadMinima= x.QuantityMin, CodigoBarra = x.Barcode})
                    .ToList()
                    .Select(y => new Product() {Id=y.Id,NameP = y.Nombre, DescriptionP = y.Description, Cost=y.Costo, QuantityMin=y.CantidadMinima, Barcode=y.CodigoBarra })
                    .ToList();
                return respuesta;
            }
        }

        /*
         * 
        */
        public List<Product> ProductosPorDeposito(int deposito)
        {
            using (var db = new AxureContext())
            {
                Deposit dep = db.Deposits.Single(x => x.Id == deposito);
                var resp = db.Stocks.Include("Products").Where(x => x.IdDeposit==dep.Id && x.Product.Delete == false)
                    .Select(x => new { Id = x.Product.Id, Nombre = x.Product.NameP, Description = x.Product.DescriptionP, Costo = x.Product.Cost, CantidadMinima = x.Product.QuantityMin, CodigoBarra = x.Product.Barcode })
                    .ToList()
                    .Select(y => new Product() { Id = y.Id, NameP = y.Nombre, DescriptionP = y.Description, Cost = y.Costo, QuantityMin = y.CantidadMinima, Barcode = y.CodigoBarra })
                    .ToList();
                return resp;
            }
        }

        public List<Product> DetalleProducto(int id)
        {
            using (var db = new AxureContext())
            {
                var respuesta = db.Products.Where(x => x.Id == id)
                    .Select(x => new { Id = x.Id, Nombre = x.NameP, Description = x.DescriptionP, Costo = x.Cost, CantidadMinima = x.QuantityMin, CodigoBarra = x.Barcode })
                    .ToList()
                    .Select(y => new Product() { Id = y.Id, NameP = y.Nombre, DescriptionP = y.Description, Cost = y.Costo, QuantityMin = y.CantidadMinima, Barcode = y.CodigoBarra })
                    .ToList();
                return respuesta;
            }
        }

        public int SumaPrecioProductoDeposito(int id)
        {
            using (var db = new AxureContext())
            {
                Deposit dep = db.Deposits.Single(x => x.Id == id);
                var resp = db.Stocks.Include("Products").Where(x => x.IdDeposit == dep.Id)
                    .Select(x => new { Id = x.Product.Id, Costo = x.Product.Cost })
                    .ToList()
                    .Select(y => new Product() { Id = y.Id, Cost = y.Costo })
                    .ToList();
                return 14;
            }

        }


        public bool Agregar(string NameP, int IdProductType, string DescriptionP, int Cost, int QuantityMin, string Barcode)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.Products.Add(new Product() { NameP = NameP, IdProductType = IdProductType, DescriptionP = DescriptionP, Cost = Cost, QuantityMin = QuantityMin, Barcode = Barcode, Delete = false });
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Editar(int id, string NameP, int IdProductType, string DescriptionP, int Cost, int QuantityMin, string Barcode)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Product producto = db.Products.FirstOrDefault(x => x.Id == id);
                    producto.NameP = NameP;
                    producto.IdProductType = IdProductType;
                    producto.DescriptionP = DescriptionP;
                    producto.Cost = Cost;
                    producto.QuantityMin = QuantityMin;
                    producto.Barcode = Barcode;
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
                    Product bajar = db.Products.FirstOrDefault(x => x.Id == id);
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
                    Product prod = db.Products.Single(x => x.Id == id);
                    if(null == prod) { return true; }
                    db.Products.Remove(prod);
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