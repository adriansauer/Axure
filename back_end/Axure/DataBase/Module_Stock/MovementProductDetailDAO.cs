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
        //Metodo privado para agregar
        private bool AgregarPriv() { return true; }

        //Metodo para agregar a la tabla
        public bool Agregar(MovementProductDetail esp)
        {
            try
            {
                using (var db = new AxureContext())
                {

                    StockDB dbDAO = new StockDB();
                    MovementProductDAO espDao = new MovementProductDAO();

                    Product pd = db.Products.Single(x => x.Id == esp.ProductId);
                    MovementProductionType espC = db.MovementProducts.Single(x=> x.Id == esp.MovementProductId);
                    Stock st = db.Stocks.Single(x => x.IdProduct == pd.Id && x.IdDeposit == espC.DepositId);

                    //pregunta si es Entrada o salida para actualizar el stock
                    if (espC.MovementTypeId == 1)//si es Entrada
                    {
                        db.MovementProductDetails.Add( new MovementProductDetail() { ProductId = esp.ProductId, MovementProductId = esp.MovementProductId, Quantity = esp.Quantity, Observation = esp.Observation, TotalCost = esp.Quantity * pd.Cost, Cost = esp.Cost});
                        //se actualiza la cabecera
                        espDao.Editar(espC.Id,new MovementProductionType { DepositId = espC.DepositId,EmployeeId = espC.EmployeeId, Reason = espC.Reason, TotalCost = espC.TotalCost + esp.TotalCost});
                        //se actualiza el stock
                        dbDAO.Editar(st.Id,new Stock {IdProduct = pd.Id, IdDeposit = espC.DepositId, Quantity = st.Quantity + esp.Quantity });
                        db.SaveChanges();
                        return true;
                    }
                    if (espC.MovementTypeId == 2)//si es salida
                    {
                        //verifica que la cantidad a sacar no sea mayor a la existente
                        if (esp.Quantity <= st.Quantity)
                        {
                            db.MovementProductDetails.Add( new MovementProductDetail() { ProductId = esp.ProductId, MovementProductId = esp.MovementProductId, Quantity = esp.Quantity, Observation = esp.Observation, TotalCost = esp.Quantity * pd.Cost, Cost = esp.Cost });
                            //se actualiza la cabecera
                            espDao.Editar(espC.Id, new MovementProductionType { DepositId = espC.DepositId, EmployeeId = espC.EmployeeId, Reason = espC.Reason, TotalCost = espC.TotalCost - esp.TotalCost });
                            //se actualiza el stock
                            dbDAO.Editar(st.Id, new Stock { IdProduct = pd.Id, IdDeposit = espC.DepositId, Quantity = st.Quantity - esp.Quantity });
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
        public List<MovementProductDetailDTO> Obtener()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var lista = db.MovementProductDetails.Where(x => x.Quantity > 0)
                        .Select(x => new
                        {
                            Id              = x.Id,
                            MovementProductId = x.MovementProductId,
                            IdProduct       = x.ProductId,
                            Quantity        = x.Quantity,
                            TotalCost       = x.TotalCost,
                            Cost            = x.Cost,
                            Observation     = x.Observation
                        })
                        .ToList()
                        .Select(y => new MovementProductDetailDTO() {
                            Id              = y.Id,
                            MovementProductId = y.MovementProductId,
                            ProductId       = y.IdProduct,
                            Quantity        = y.Quantity,
                            TotalCost       = y.TotalCost,
                            Cost            = y.Cost,
                            Observation     = y.Observation
                        })
                        .ToList();
                    return lista;
                }
            }
            catch
            {
                return null ;
            }
        }


        //Cambiar de nuevo
        
        //Obtener productos por id de cabecera
        public List<MovementProductDetailDTO> ObtenerPorNro(int id)
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

        //Eliminar 
        public bool Eliminar(int id)
        {
            try
            {
                using (var db  =  new AxureContext())
                {
                    MovementProductDetail esp = db.MovementProductDetails.Single(x => x.Id == id);
                    MovementProductionType espC = db.MovementProducts.Single(x => x.Id == esp.MovementProductId);
                    Product pd = db.Products.Single(x => x.Id == esp.ProductId);
                    Stock st = db.Stocks.Single(x => x.IdProduct == pd.Id && x.IdDeposit == espC.DepositId);

                    MovementProductDAO espDAO = new MovementProductDAO();
                    StockDB dbDAO = new StockDB();

                    //pregunta si es entrada o salida
                    if (espC.MovementTypeId == 1) //si es entrada
                    {
                        if (esp.Quantity <= st.Quantity)
                        {
                            //actualiza el costo de la cabecera
                            espDAO.Editar(esp.MovementProductId, new MovementProductionType() { DepositId = espC.DepositId, EmployeeId = espC.EmployeeId, MovementTypeId = espC.MovementTypeId, Reason = espC.Reason, Number = espC.Number, Date = espC.Date, TotalCost = espC.TotalCost - esp.TotalCost });
                            //se actualiza el stock
                            dbDAO.Editar(st.Id, new Stock { IdProduct = pd.Id, IdDeposit = espC.DepositId, Quantity = st.Quantity - esp.Quantity });
                            db.MovementProductDetails.Remove(esp);
                            db.SaveChanges();
                            return true;
                        }
                        else return false;
                    }
                    if (espC.MovementTypeId == 2)//si es salida
                    {
                        //actualiza el costo de la cabecera
                        espDAO.Editar(esp.MovementProductId, new MovementProductionType() { DepositId = espC.DepositId, EmployeeId = espC.EmployeeId, MovementTypeId = espC.MovementTypeId, Reason = espC.Reason, Number = espC.Number, Date = espC.Date, TotalCost = espC.TotalCost - esp.TotalCost });
                        //se actualiza el stock
                        dbDAO.Editar(st.Id, new Stock { IdProduct = pd.Id, IdDeposit = espC.DepositId, Quantity = st.Quantity + esp.Quantity });
                        db.MovementProductDetails.Remove(esp);
                        db.SaveChanges();
                        return true;
                    }
                    else return false;
                    
                }
            }
            catch
            {
                return false;
            }
        }

        //Editar
        public bool Editar(int id, MovementProductDetail esp)
        {
            try
            {
                using (var db  = new AxureContext())
                {
                    int cantAux = esp.Quantity;

                    MovementProductionType espC = db.MovementProducts.Single(x => x.Id == esp.MovementProductId);
                    Product pd = db.Products.Single(x => x.Id == esp.ProductId);
                    Stock st = db.Stocks.Single(x => x.IdProduct == pd.Id && x.IdDeposit == espC.DepositId);

                    StockDB dbDAO = new StockDB();

                    if (esp.Quantity <= st.Quantity)
                    {
                        MovementProductDetail espD = db.MovementProductDetails.FirstOrDefault(x => x.Id == id);
                        espD.MovementProductId = esp.MovementProductId;
                        espD.ProductId = esp.ProductId;
                        espD.Observation = esp.Observation;
                        espD.Quantity = esp.Quantity;
                        espD.Cost = esp.Cost;
                        espD.TotalCost = esp.TotalCost;

                        //se actualiza el stock
                        dbDAO.Editar(st.Id, new Stock { IdProduct = pd.Id, IdDeposit = espC.DepositId, Quantity = st.Quantity - cantAux + esp.Quantity });

                        db.SaveChanges();
                        return true;
                    }
                    else return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}