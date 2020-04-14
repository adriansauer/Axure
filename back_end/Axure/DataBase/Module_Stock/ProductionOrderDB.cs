using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Axure.DataBase.Module_Stock;
using Axure.Models;

namespace Axure.DataBase.Module_Stock
{
    public class ProductionOrderDB
    {

        ProductsDB productDB;

        public ProductionOrderDB()
        {
            this.productDB = new ProductsDB();
        }

        /*
         * Metodo ObtenerTodosProductos, retorna todos los productos que tiene registrado.
        */
        public List<ProductionOrderDB> ObtenerTodosProductos()
        {
            try
            {
                using (var db = new AxureContext())
                {

                    /*   var respuesta = db.Products.Include("ProductTypes").Where(x => x.Delete == false)
                           .Select(x => new { Id = x.Id, ProductType = x.ProductType, Nombre = x.NameP, Description = x.DescriptionP, Costo = x.Cost, CantidadMinima = x.QuantityMin, CodigoBarra = x.Barcode })
                           .ToList()
                           .Select(y => new ProductDTO() { Id = y.Id, ProductType = y.ProductType, NameP = y.Nombre, DescriptionP = y.Description, Cost = y.Costo, QuantityMin = y.CantidadMinima, Barcode = y.CodigoBarra })
                           .ToList();
                       return respuesta;*/
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        /*
         * 
        */
        public List<ProductionOrderDB> ProductosPorEstado(int deposito)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    /*Deposit depos = db.Deposits.Single(x => x.Id == deposito);
                    var stocks = db.Stocks.Include("Products").Where(x => x.IdDeposit == depos.Id).Select(x => new { Id = x.Product.Id }).ToList();
                    List<Product> listaProductos = new List<Product>();
                    stocks.ForEach(x => listaProductos.Add(db.Products.Include("ProductType").Single(w => w.Id == x.Id && w.Delete == false)));
                    var productos = listaProductos
                        .Select(x => new { Id = x.Id, ProductType = x.ProductType, Nombre = x.NameP, Description = x.DescriptionP, Costo = x.Cost, CantidadMinima = x.QuantityMin, CodigoBarra = x.Barcode })
                        .ToList()
                        .Select(y => new ProductDTO() { Id = y.Id, ProductType = y.ProductType, NameP = y.Nombre, DescriptionP = y.Description, Cost = y.Costo, QuantityMin = y.CantidadMinima, Barcode = y.CodigoBarra })
                        .ToList();
                    return productos;*/
                    return null;
                }
            }
            catch
            {
                return null;
            }

        }

        public ProductionOrderDB DetalleOrdenProduccion(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                   // var p = db.Products.Include("ProductType").FirstOrDefault(x => x.Id == id && x.Delete == false);

                    //return new ProductDTO() { Id = p.Id, ProductType = p.ProductType, NameP = p.NameP, DescriptionP = p.DescriptionP, Cost = p.Cost, QuantityMin = p.QuantityMin, Barcode = p.Barcode };
                    return null;
                }
            }
            catch
            {
                return null;
            }

        }

        public bool AgregarOrdenSinComponentes(ProductionOrderDB orden)
        {
            try
            {
                using (var db = new AxureContext())
                {
                   // db.Products.Add(new Product() { NameP = pc.NameP, IdProductType = pc.IdProductType, DescriptionP = pc.DescriptionP, Cost = pc.Cost, QuantityMin = pc.QuantityMin, Barcode = pc.Barcode, Delete = false });
                   // db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool AgregarOrdenConComponentes(ProductionOrderDB orden)
        {
            try
            {
                using (var db = new AxureContext())
                {
                   /* Product nuevo = new Product() { NameP = pc.NameP, IdProductType = pc.IdProductType, DescriptionP = pc.DescriptionP, Cost = pc.Cost, QuantityMin = pc.QuantityMin, Barcode = pc.Barcode, Delete = false };
                    db.Products.Add(nuevo);
                    db.SaveChanges();
                    for (int i = 0; i < pc.listaComponentes.Count; i++)
                    {
                        this.componentDB.agregar(new ProductComponent() { IdProduct = nuevo.Id, IdProductComponent = pc.listaComponentes[i].IdProductComponent, Quantity = pc.listaComponentes[i].Quantity });
                    }*/
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Editar(int id, ProductionOrderDB prod)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    /*Product producto = db.Products.FirstOrDefault(x => x.Id == id);
                    producto.NameP = prod.NameP;
                    producto.IdProductType = prod.IdProductType;
                    producto.DescriptionP = prod.DescriptionP;
                    producto.Cost = prod.Cost;
                    producto.QuantityMin = prod.QuantityMin;
                    producto.Barcode = prod.Barcode;
                    db.SaveChanges();*/
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
                    /*Product bajar = db.Products.FirstOrDefault(x => x.Id == id);
                    bajar.Delete = true;
                    db.SaveChanges();*/
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
                   /* Product prod = db.Products.Single(x => x.Id == id);
                    if (null == prod) { return true; }
                    db.Products.Remove(prod);
                    db.SaveChanges();*/
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