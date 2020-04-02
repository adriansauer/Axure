using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Stock
{
    public class StockDB
    {
        ProductsDB productDB;
        public StockDB()
        {
            this.productDB = new ProductsDB();
        }

        public StockDTO DetalleStock(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                   var st = db.Stocks.FirstOrDefault(x => x.Id == id);
                    return new StockDTO() { Id = st.Id, IdDeposit = st.IdDeposit, IdProduct = st.IdProduct, Quantity = st.Quantity};
                }
            }
            catch
            {
                return null;
            }
        }

        public int CantidadProducto(int idProducto, Deposit dep)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    return db.Stocks.FirstOrDefault(x => x.IdDeposit == idProducto && x.IdDeposit == dep.Id).Quantity;
                }
            }
            catch
            {
                return -1;
            }
        }


        public bool Agregar(Stock st)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.Stocks.Add(st);
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Editar(int id, Stock st)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Stock stock = db.Stocks.FirstOrDefault(x => x.Id == id);
                    stock.IdProduct = st.IdProduct;
                    stock.IdDeposit = st.IdDeposit;
                    stock.Quantity = st.Quantity;
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
                    Stock st = db.Stocks.Single(x => x.Id == id);
                    if (null == st) { return true; }
                    db.Stocks.Remove(st);
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