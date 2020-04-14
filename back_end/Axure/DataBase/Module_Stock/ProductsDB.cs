﻿using Axure.Controllers;
using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using Axure.Models.Module_Stock.Models;
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
namespace Axure.DataBase.Module_Stock
{
    public class ProductsDB
    {
        ComponentDB componentDB;

        public ProductsDB()
        {
            this.componentDB = new ComponentDB();
        }

        /*
         * Metodo ObtenerTodosProductos, retorna todos los productos que tiene registrado.
        */
        public List<ProductDTO> ObtenerTodosProductos()
        {
            try
            {
                using (var db = new AxureContext())
                {   
                    
                    var respuesta = db.Products.Include("ProductTypes").Where(x => x.Delete == false)
                        .Select(x => new { Id = x.Id,ProductType = x.ProductType, Nombre = x.NameP, Description = x.DescriptionP, Costo = x.Cost, CantidadMinima = x.QuantityMin, CodigoBarra = x.Barcode })
                        .ToList()
                        .Select(y => new ProductDTO() { Id = y.Id,ProductType = y.ProductType, NameP = y.Nombre, DescriptionP = y.Description, Cost = y.Costo, QuantityMin = y.CantidadMinima, Barcode = y.CodigoBarra })
                        .ToList();
                    return respuesta;                      
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
        public List<ProductDTO> ProductosPorDeposito(int deposito)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Deposit depos = db.Deposits.Single(x => x.Id == deposito);
                    var stocks = db.Stocks.Include("Products").Where(x => x.IdDeposit == depos.Id).Select(x => new {Id = x.Product.Id }).ToList();
                    List<Product> listaProductos = new List<Product>();
                    stocks.ForEach(x => listaProductos.Add(db.Products.Include("ProductType").Single(w => w.Id == x.Id && w.Delete == false)));
                    var productos = listaProductos
                        .Select(x => new { Id = x.Id, ProductType = x.ProductType, Nombre = x.NameP, Description = x.DescriptionP, Costo = x.Cost, CantidadMinima = x.QuantityMin, CodigoBarra = x.Barcode })
                        .ToList()
                        .Select(y => new ProductDTO() { Id = y.Id, ProductType = y.ProductType, NameP = y.Nombre, DescriptionP = y.Description, Cost = y.Costo, QuantityMin = y.CantidadMinima, Barcode = y.CodigoBarra })
                        .ToList();
                    return productos;
                }
            }
            catch
            {
                return null;
            }
            
        }

        public ProductDTO DetalleProducto(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var p = db.Products.Include("ProductType").FirstOrDefault(x => x.Id == id && x.Delete == false);
                       
                    return new ProductDTO() { Id = p.Id, ProductType = p.ProductType, NameP = p.NameP, DescriptionP = p.DescriptionP, Cost = p.Cost, QuantityMin = p.QuantityMin, Barcode = p.Barcode };
                }
            }
            catch
            {
                return null;
            }
           
        }

        public int SumaPrecioProductoDeposito(int id)
        {
            using (var db = new AxureContext())
            {
                Deposit dep = db.Deposits.Single(x => x.Id == id);
                int suma = 0;
                try
                {
                    suma = db.Stocks.Include("Products").Where(x => x.IdDeposit == dep.Id && x.Product.Delete == false).Sum(z => z.Product.Cost * z.Quantity);
                    return suma;
                }
                catch
                {
                    return suma;
                }
            }

        }


        public bool Agregar(Pc pc)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.Products.Add(new Product() { NameP = pc.NameP, IdProductType = pc.IdProductType, DescriptionP = pc.DescriptionP, Cost = pc.Cost, QuantityMin = pc.QuantityMin, Barcode = pc.Barcode, Delete = false });
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool AgregarPcComponentes(Pc pc)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Product nuevo = new Product() { NameP = pc.NameP, IdProductType = pc.IdProductType, DescriptionP = pc.DescriptionP, Cost = pc.Cost, QuantityMin = pc.QuantityMin, Barcode = pc.Barcode, Delete = false };
                    db.Products.Add(nuevo);
                    db.SaveChanges();
                    for (int i = 0; i < pc.listaComponentes.Count; i++)
                    {
                        this.componentDB.agregar(new ProductComponent() { IdProduct = nuevo.Id, IdProductComponent = pc.listaComponentes[i].IdProductComponent, Quantity = pc.listaComponentes[i].Quantity });
                    }
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Editar(int id, Product prod)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Product producto = db.Products.FirstOrDefault(x => x.Id == id);
                    producto.NameP = prod.NameP;
                    producto.IdProductType = prod.IdProductType;
                    producto.DescriptionP = prod.DescriptionP;
                    producto.Cost = prod.Cost;
                    producto.QuantityMin = prod.QuantityMin;
                    producto.Barcode = prod.Barcode;
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