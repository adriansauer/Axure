using Axure.DTO;
using Axure.DTO.Module_Purchase;
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

        public List<ProductDTO> StockDeposit(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var st = db.Stocks.Include("Products").Where(x => x.DepositId == id && x.Deleted == false)
                        .Select(x => new { Id = x.Id, DepositId = x.DepositId, Product = x.Product, Quantity = x.Quantity })
                        .ToList();
                    List<ProductDTO> re = st.Select(y => new ProductDTO() { 
                        Id = y.Id, 
                        Name = y.Product.Name, 
                        Description = y.Product.Description,                   
                        Cost = y.Product.Cost, 
                        Price = y.Product.Price, 
                        TaxPercentage = 10, 
                        QuantityMin = y.Product.QuantityMin, 
                        QuantityStock= y.Quantity, 
                        Barcode = y.Product.Barcode, 
                        ProductCategoryId = y.Product.ProductCategoryId 
                    })
                           .ToList();
                    return re;
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

        public List<int> CheckStock (List<ProductQuantityDTO> listDetails, int idDeposit)
        {
            try
            {
                List<int> notStock = new List<int>();
                SettingDAO settingDAO = new SettingDAO();
                for (int i = 0; i < listDetails.Count; i++)
                {                   
                    int cant = ProductQuantity(listDetails[i].ProductId, new Deposit{ Id = idDeposit });
                    if (listDetails[i].Quantity > cant) { notStock.Add(listDetails[i].ProductId); }
                }
                return notStock;
            }
            catch
            {
                return null;
            }
        }

        //editar cantidad
        public bool UpdateQuantity(Stock stock, int productId, int quantity)
        {
            try
            {
                using(var db = new AxureContext())
                {
                    Stock st = db.Stocks.FirstOrDefault(x=> x.Id == stock.Id && x.ProductId == productId && x.DepositId == stock.DepositId);
                    st.Quantity = quantity;
                    db.SaveChanges();
                    return true;// retorna true si se actualizo correctamente
                }
            }
            catch
            {
                return false;//retorna false si no pudo realizar la actualizacion
            }
        }

        public bool DecreaseProductsQuantity(List<ProductQuantityDTO> listItems, int idDeposit)
        {
            using (var db = new AxureContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach(ProductQuantityDTO product in listItems)
                        {
                            Stock st = db.Stocks.FirstOrDefault(x => x.ProductId == product.ProductId && x.DepositId == idDeposit);
                            int newQuantity = st.Quantity - product.Quantity;
                            if(newQuantity < 0)
                            {
                                throw new System.Exception();
                            }
                            st.Quantity = newQuantity;
                            db.SaveChanges();
                        }
                        dbContextTransaction.Commit();
                        return false;
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        return true;
                    }
                }
            }
        }

        public bool IncreaseProductsQuantity(List<PurchaseInvoiceItemDTO> listItems, int idDeposit)
        {
            using (var db = new AxureContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (PurchaseInvoiceItemDTO product in listItems)
                        {
                            Stock st = db.Stocks.FirstOrDefault(x => x.ProductId == product.ProductId && x.DepositId == idDeposit);
                            int newQuantity = st.Quantity + product.Quantity;
                            if (newQuantity < 0)
                            {
                                throw new System.Exception();
                            }
                            st.Quantity = newQuantity;
                            db.SaveChanges();
                        }
                        dbContextTransaction.Commit();
                        return false;
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        return true;
                    }
                }
            }
        }
    }
}