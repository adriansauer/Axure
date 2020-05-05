using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Http;


/*
 * Creado por Enzo Ramirez
 * 04/09/2020
 */
namespace Axure.DataBase.Module_Stock
{
    public class MovementProductDetailDAO
    {
        Stock st;
        //Metodo para agregar a la tabla
        public bool Add(MovementProductDetailDTO esp)
        {
            try
            {
                using (var db = new AxureContext())
                {

                    StockDAO dbDAO = new StockDAO();
                    MovementProductDAO espDao = new MovementProductDAO();
                    Product pd = db.Products.Single(x => x.Id == esp.ProductId);
                    MovementProduct espC = db.MovementProducts.Single(x => x.Id == esp.MovementProductId);
                    //MovementMotive mt = db.MovementMotives.Single(x => x.Id == espC.MovementMotiveId);

                    try
                    {           
                        st = db.Stocks.Single(x => x.ProductId == pd.Id && x.DepositId == espC.DepositId);          //intenta encontrar el stock del producto si lo encuentra perfecto
                    }
                    catch
                    {           // si no lo encuentra st pasa a ser null
                        st = null;
                    }

                    Setting stgE = db.Settings.Single(x => x.Key == "ID_ENTRY_PRODUCT");
                    Setting stgO = db.Settings.Single(x => x.Key == "ID_OUTPUT_PRODUCT");


                    //pregunta si es Entrada o salida para actualizar el stock
                    if (espC.MovementTypeId == int.Parse(stgE.Value))//si es Entrada
                    {
                        if (st != null) //si existe el stock agrega el detalle actualiza el costo total de la cabecera y actualiza el stock del producto
                        {

                            db.MovementProductDetails.Add(new MovementProductDetail() { ProductId = esp.ProductId, MovementProductId = esp.MovementProductId, Quantity = esp.Quantity, Observation = esp.Observation, TotalCost = esp.Quantity * pd.Cost, Cost = pd.Cost });
                            espDao.UpdateTotalCost(espC, espC.TotalCost + (pd.Cost * esp.Quantity));//se actualiza la cabecera
                            dbDAO.UpdateQuantity(st, pd.Id, st.Quantity + esp.Quantity);//se actualiza el stock
                            db.SaveChanges();
                            return true;
                        }
                        else            //si no existe el stock del producto crear un stock del producto
                        {
                            dbDAO.Add(new StockDTO { ProductId = esp.ProductId, DepositId = espC.DepositId, Quantity = esp.Quantity });
                            db.MovementProductDetails.Add(new MovementProductDetail() { ProductId = esp.ProductId, MovementProductId = esp.MovementProductId, Quantity = esp.Quantity, Observation = esp.Observation, TotalCost = esp.Quantity * pd.Cost, Cost = pd.Cost });
                            espDao.UpdateTotalCost(espC, espC.TotalCost + (pd.Cost * esp.Quantity));//se actualiza la cabecera
                            return true;
                        }
                    }
                    if (espC.MovementTypeId == int.Parse(stgO.Value))//si es salida   
                    {
                        //verifica que la cantidad a sacar no sea mayor a la existente
                        if (esp.Quantity <= st.Quantity)
                        {
                            db.MovementProductDetails.Add(new MovementProductDetail() { ProductId = esp.ProductId, MovementProductId = esp.MovementProductId, Quantity = esp.Quantity, Observation = esp.Observation, TotalCost = esp.Quantity * pd.Cost, Cost = pd.Cost });
                            espDao.UpdateTotalCost(espC, espC.TotalCost - (pd.Cost * esp.Quantity));//se actualiza la cabecera
                            dbDAO.UpdateQuantity(st, pd.Id, st.Quantity - esp.Quantity); //se actualiza el stock
                            db.SaveChanges();
                            return true;
                        }
                        else return false;
                    }
                    else return false;
                }
            }
            catch
            {
                return false;
            }
        }

        //Metodo para obterner todos los productos de entrada o salida
        public List<MovementProductDetailDTO> List()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var lista = db.MovementProductDetails.Where(x => x.Quantity > 0)
                        .Select(x => new
                        {
                            Id = x.Id,
                            MovementProductId = x.MovementProductId,
                            IdProduct = x.ProductId,
                            Quantity = x.Quantity,
                            TotalCost = x.TotalCost,
                            Cost = x.Cost,
                            Observation = x.Observation
                        })
                        .ToList()
                        .Select(y => new MovementProductDetailDTO()
                        {
                            Id = y.Id,
                            MovementProductId = y.MovementProductId,
                            ProductId = y.IdProduct,
                            Quantity = y.Quantity,
                            TotalCost = y.TotalCost,
                            Cost = y.Cost,
                            Observation = y.Observation
                        })
                        .ToList();
                    return lista;
                }
            }
            catch
            {
                return null;
            }
        }

        //Obtener productos por id de cabecera
        public List<MovementProductDetailDTO> ListByMaster(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var lista = db.MovementProductDetails.Where(x => x.MovementProductId == id)
                        .Select(x => new
                        {
                            Id = x.Id,
                            MovementProductId = x.MovementProductId,
                            ProductId = x.ProductId,
                            Quantity = x.Quantity,
                            TotalCost = x.TotalCost,
                            Cost = x.Cost,
                            Observation = x.Observation
                        })
                        .ToList()
                        .Select(y => new MovementProductDetailDTO()
                        {
                            Id = y.Id,
                            MovementProductId = y.MovementProductId,
                            ProductId = y.ProductId,
                            Quantity = y.Quantity,
                            TotalCost = y.TotalCost,
                            Cost = y.Cost,
                            Observation = y.Observation
                        })
                        .ToList();
                    return lista;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}