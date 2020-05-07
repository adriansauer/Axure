﻿using Axure.DTO.Module_Stock;
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

        public List<int> CheckStock (List<ProductionOrderDetailDTO> listDetails, int idDeposit)
        {
            try
            {
                List<int> notStock = new List<int>();
                SettingDAO settingDAO = new SettingDAO();
                for (int i = 0; i < listDetails.Count; i++)
                {
                    ComponentDAO componentDAO = new ComponentDAO();
                    List<ProductComponentDTO> components = componentDAO.GetComponentOfProduct(listDetails[i].ProductId);
                    if (0 < components.Count)
                    {
                        for(int z = 0; z < components.Count; z++)
                        {
                            int cant = ProductQuantity(components[z].ProductComponentId, new Deposit { Id = idDeposit });
                            if ((listDetails[i].Quantity * components[z].Quantity) >= cant) { 
                                notStock.Add(listDetails[i].ProductId);
                                z = components.Count;
                            }
                        }
                    }
                    else
                    {
                        int cant = ProductQuantity(listDetails[i].ProductId, new Deposit { Id = idDeposit });
                        if (listDetails[i].Quantity >= cant)
                        {
                            notStock.Add(listDetails[i].ProductId);
                        }
                    }                 
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

        public bool UpdateQuant(Stock stock, int quantity)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Stock st = db.Stocks.FirstOrDefault(x => x.Id == stock.Id);
                    st.Quantity += quantity;
                    db.SaveChanges();
                    return false;// retorna true si se actualizo correctamente
                }
            }
            catch
            {
                return true;//retorna false si no pudo realizar la actualizacion
            }
        }

        public bool ModificarCantidad(int productId, int depositId, int cant)
        {
            try
            {
                if(cant >= 0)
                {
                    using (var db = new AxureContext())
                    {
                        Stock st = db.Stocks.FirstOrDefault(x => x.ProductId == productId && x.DepositId == depositId && x.Deleted == false);
                        if(null == st)
                        {
                            Add(new StockDTO { DepositId = depositId, ProductId = productId, Quantity = cant });                      
                        }
                        else
                        {
                            if(UpdateQuant(st, cant)) { return true; }
                        }
                    }
                }
                else
                {
                    using (var db = new AxureContext())
                    {
                        Stock st = db.Stocks.FirstOrDefault(x => x.ProductId == productId && x.DepositId == depositId && x.Deleted == false);
                        if (null == st)
                        {
                            return true;
                        }
                        else if(st.Quantity >= (cant * - 1))
                        {
                            if (UpdateQuant(st, cant)) { return true; }
                        }
                    }
                }
                return false;
            }
            catch
            {
                return true;
            }
        }

        public bool TransferProduct(int productId, int cant, int depositIdOrigin, int depostIdDestination)
        {
            try
            {
                if (ModificarCantidad(productId, depositIdOrigin, cant * -1))
                {
                    return true;
                }
                else
                {
                    if (ModificarCantidad(productId, depostIdDestination, cant))
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return true;
            }
        }


        public bool TransferProductSacar(int productId, int cant, int depositIdOrigin, int depostIdDestination)
        {
            try
            {
                if (ModificarCantidad(productId, depositIdOrigin, cant * -1))
                {
                    return true;
                }
                
                return false;
            }
            catch
            {
                return true;
            }
        }





    }
}