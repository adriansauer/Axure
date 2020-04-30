using Axure.Controllers;
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
 * ProductDAO class
 * Created march 10, 2020 by Victor Ciceia.
 */
namespace Axure.DataBase.Module_Stock
{
    public class ProductDAO
    {
       ComponentDAO componentDB;

        public ProductDAO()
        {
            this.componentDB = new ComponentDAO();
        }

        public List<ProductDTO> GetAll()
        {
            try
            {
                using (var db = new AxureContext())
                {   
                    
                    var respuesta = db.Products.Include("ProductTypes").Where(x => x.Deleted == false)
                        .Select(x => new { Id = x.Id,ProductType = x.ProductType, Name = x.Name, Description = x.Description, Costo = x.Cost, CantidadMinima = x.QuantityMin, CodigoBarra = x.Barcode })
                        .ToList()
                        .Select(y => new ProductDTO() { Id = y.Id,ProductType = y.ProductType, Name = y.Name, Description = y.Description, Cost = y.Costo, QuantityMin = y.CantidadMinima, Barcode = y.CodigoBarra })
                        .ToList();
                    return respuesta;                      
                }
            }
            catch
            {
                return null;
            }
        }
        
        public List<ProductDTO> ProductDeposit (int deposit)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Deposit depos = db.Deposits.Single(x => x.Id == deposit);
                    var stocks = db.Stocks.Include("Products").Where(x => x.DepositId == depos.Id).Select(x => new {Id = x.Product.Id }).ToList();
                    List<Product> listaProductos = new List<Product>();
                    stocks.ForEach(x => listaProductos.Add(db.Products.Include("ProductType").Single(w => w.Id == x.Id && w.Deleted == false)));
                    var productos = listaProductos
                        .Select(x => new { Id = x.Id, ProductType = x.ProductType, Name = x.Name, Description = x.Description, Costo = x.Cost, CantidadMinima = x.QuantityMin, CodigoBarra = x.Barcode })
                        .ToList()
                        .Select(y => new ProductDTO() { Id = y.Id, ProductType = y.ProductType, Name = y.Name, Description = y.Description, Cost = y.Costo, QuantityMin = y.CantidadMinima, Barcode = y.CodigoBarra })
                        .ToList();
                    return productos;
                }
            }
            catch
            {
                return null;
            }
            
        }

        public List<ProductDTO> ProductType(int type)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var respuesta = db.Products.Where(x => x.Deleted == false && x.ProductTypeId == type)
                          .Select(x => new { Id = x.Id, ProductType = x.ProductType, Name = x.Name, Description = x.Description, Costo = x.Cost, CantidadMinima = x.QuantityMin, CodigoBarra = x.Barcode })
                          .ToList()
                          .Select(y => new ProductDTO() { Id = y.Id, Name = y.Name, Description = y.Description, Cost = y.Costo, QuantityMin = y.CantidadMinima, Barcode = y.CodigoBarra })
                          .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }

        }

        public ProductDTO Detail(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var p = db.Products.Include("ProductType").FirstOrDefault(x => x.Id == id && x.Deleted == false);                      
                    return new ProductDTO() { Id = p.Id, ProductType = p.ProductType, Name = p.Name, Description = p.Description, Cost = p.Cost, QuantityMin = p.QuantityMin, Barcode = p.Barcode };
                }
            }
            catch
            {
                return null;
            }
           
        }

        public int SumProductPricesDeposit(int id)
        {
            using (var db = new AxureContext())
            {
                Deposit dep = db.Deposits.Single(x => x.Id == id);
                int suma = 0;
                try
                {
                    suma = db.Stocks.Include("Products").Where(x => x.DepositId == dep.Id && x.Product.Deleted == false).Sum(z => z.Product.Cost * z.Quantity);
                    return suma;
                }
                catch
                {
                    return suma;
                }
            }

        }


        public bool Add(Pc pc)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.Products.Add(new Product() { Name = pc.Name, ProductTypeId = pc.ProductTypeId, Description = pc.Description, Cost = pc.Cost, QuantityMin = pc.QuantityMin, Barcode = pc.Barcode, Deleted = false });
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool AddPc(Pc pc)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Product nuevo = new Product() { Name = pc.Name, ProductTypeId = pc.ProductTypeId, Description = pc.Description, Cost = pc.Cost, QuantityMin = pc.QuantityMin, Barcode = pc.Barcode, Deleted = false };
                    db.Products.Add(nuevo);
                    db.SaveChanges();
                    for (int i = 0; i < pc.ListComponents.Count; i++)
                    {
                        this.componentDB.Add(new ProductComponentDTO() { ProductId = nuevo.Id, ProductComponentId = pc.ListComponents[i].ProductComponentId, Quantity = pc.ListComponents[i].Quantity });
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
                    Product producto = db.Products.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    producto.Name = prod.Name;
                    producto.ProductTypeId = prod.ProductTypeId;
                    producto.Description = prod.Description;
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

        public bool Remove(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Product bajar = db.Products.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    bajar.Deleted = true;
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