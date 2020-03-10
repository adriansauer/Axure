using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
                var respuesta = db.Products
                    .Select(x => new {Id= x.Id, Nombre = x.NameP, Descripcion =x.DescriprionP, Costo = x.Cost, CantidadMinima= x.QuantityMin, CodigoBarra = x.Barcode})
                    .ToList()
                    .Select(y => new Product() {Id=y.Id,NameP = y.Nombre, DescriprionP = y.Descripcion, Cost=y.Costo, QuantityMin=y.CantidadMinima, Barcode=y.CodigoBarra })
                    .ToList();
                return respuesta;
            }
        }

        /*
         * 
        */
        public List<ProductDTO> ProductosPorDeposito(string deposito)
        {
            using (var db = new AxureContext())
            {
                Deposit dep = db.Deposits.Single(x => x.Code.Equals(deposito));
                var stock = db.Stocks.Where(x => x.IdDeposit==dep.Id).ToList();


                var respuesta = db.Products
                    .Select(x => new { Nombre = x.NameP, Descripcion = x.DescriprionP, Costo = x.Cost, CantidadMinima = x.QuantityMin, CodigoBarra = x.Barcode })
                    .ToList()
                    .Select(y => new ProductDTO() { NameP = y.Nombre, DescriprionP = y.Descripcion, Cost = y.Costo, QuantityMin = y.CantidadMinima, Barcode = y.CodigoBarra })
                    .ToList();
                return respuesta;
            }
        }
    }
}