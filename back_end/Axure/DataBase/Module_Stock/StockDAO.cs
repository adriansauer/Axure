using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * StockDAO class
 * Created april 20, 2020 by Victor Ciceia.
 */
namespace Axure.DataBase.Module_Stock
{
    public class StockDAO
    {
        ProductDAO productDAO;
        public StockDAO()
        {
            this.productDAO = new ProductDAO();
        }

        public StockDTO Detail(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                   var st = db.Stocks.FirstOrDefault(x => x.Id == id);
                    return new StockDTO() { Id = st.Id, DepositId = st.DepositId, ProductId = st.ProductId, Quantity = st.Quantity};
                }
            }
            catch
            {
                return null;
            }
        }

        public int ProductQuantity(int ProductId, Deposit dep)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    return db.Stocks.FirstOrDefault(x => x.ProductId == ProductId && x.DepositId == dep.Id).Quantity;
                }
            }
            catch
            {
                return -1;
            }
        }


        public bool Add (StockDTO st)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.Stocks.Add(new Stock { ProductId = st.ProductId, DepositId = st.DepositId, Quantity = st.Quantity, Deleted = false });
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Edit (int id, StockDTO st)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Stock stock = db.Stocks.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    stock.ProductId = st.ProductId;
                    stock.DepositId = st.DepositId;
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

        public bool Remove(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Stock bajar = db.Stocks.FirstOrDefault(x => x.Id == id && x.Deleted == false);
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

        public bool Deleted (int id)
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