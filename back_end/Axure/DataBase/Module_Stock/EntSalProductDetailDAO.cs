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
    public class EntSalProductDetailDAO
    {
        //Metodo privado para agregar
        private bool AgregarPriv() { return true; }

        //Metodo para agregar a la tabla
        public bool Agregar(EntSalProductDetail esp)
        {
            try
            {
                using (var db = new AxureContext())
                {

                    StockDB dbDAO = new StockDB();
                    EntSalProductDAO espDao = new EntSalProductDAO();

                    Product pd = db.Products.Single(x => x.Id == esp.IdProduct);
                    EntSalProduct espC = db.EntSalProducts.Single(x=> x.Id == esp.IdEntSalProduct);
                    Stock st = db.Stocks.Single(x => x.IdProduct == pd.Id && x.IdDeposit == espC.IdDeposit);

                    //pregunta si es Entrada o salida para actualizar el stock
                    if (espC.IdEntSalType == 1)//si es Entrada
                    {
                        db.EntSalProductDetails.Add( new EntSalProductDetail() { IdProduct = esp.IdProduct, IdEntSalProduct = esp.IdEntSalProduct, Quantity = esp.Quantity, Observation = esp.Observation, TotalCost = esp.Quantity * pd.Cost});
                        //se actualiza la cabecera
                        espDao.Editar(espC.Id,new EntSalProduct { IdDeposit = espC.IdDeposit,IdEmployee = espC.IdEmployee, Reason = espC.Reason, TotalCost = espC.TotalCost + esp.TotalCost});
                        //se actualiza el stock
                        dbDAO.Editar(st.Id,new Stock {IdProduct = pd.Id, IdDeposit = espC.IdDeposit, Quantity = st.Quantity + esp.Quantity });
                        db.SaveChanges();
                        return true;
                    }
                    if (espC.IdEntSalType == 2)//si es salida
                    {
                        //verifica que la cantidad a sacar no sea mayor a la existente
                        if (esp.Quantity <= st.Quantity)
                        {
                            db.EntSalProductDetails.Add( new EntSalProductDetail() { IdProduct = esp.IdProduct, IdEntSalProduct = esp.IdEntSalProduct, Quantity = esp.Quantity, Observation = esp.Observation, TotalCost = esp.Quantity * pd.Cost });
                            //se actualiza la cabecera
                            espDao.Editar(espC.Id, new EntSalProduct { IdDeposit = espC.IdDeposit, IdEmployee = espC.IdEmployee, Reason = espC.Reason, TotalCost = espC.TotalCost - esp.TotalCost });
                            //se actualiza el stock
                            dbDAO.Editar(st.Id, new Stock { IdProduct = pd.Id, IdDeposit = espC.IdDeposit, Quantity = st.Quantity - esp.Quantity });
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
        public List<EntSalProductDetailDTO> Obtener()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var lista = db.EntSalProductDetails.Where(x => x.Quantity > 0)
                        .Select(x => new
                        {
                            Id              = x.Id,
                            IdEntSalProduct = x.IdEntSalProduct,
                            IdProduct       = x.IdProduct,
                            Quantity        = x.Quantity,
                            TotalCost       = x.TotalCost,
                            Observation     = x.Observation
                        })
                        .ToList()
                        .Select(y => new EntSalProductDetailDTO() {
                            Id              = y.Id,
                            IdEntSalProduct = y.IdEntSalProduct,
                            IdProduct       = y.IdProduct,
                            Quantity        = y.Quantity,
                            TotalCost       = y.TotalCost,
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
        public List<EntSalProductDetailDTO> ObtenerPorNro(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var lista = db.EntSalProductDetails.Where(x => x.IdEntSalProduct == id)
                        .Select(x => new
                        {
                            Id = x.Id,
                            IdEntSalProduct = x.IdEntSalProduct,
                            IdProduct = x.IdProduct,
                            Quantity = x.Quantity,
                            TotalCost = x.TotalCost,
                            Observation = x.Observation
                        })
                        .ToList()
                        .Select(y => new EntSalProductDetailDTO()
                        {
                            Id = y.Id,
                            IdEntSalProduct = y.IdEntSalProduct,
                            IdProduct = y.IdProduct,
                            Quantity = y.Quantity,
                            TotalCost = y.TotalCost,
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
                    EntSalProductDetail esp = db.EntSalProductDetails.Single(x => x.Id == id);
                    EntSalProduct espC = db.EntSalProducts.Single(x => x.Id == esp.IdEntSalProduct);
                    Product pd = db.Products.Single(x => x.Id == esp.IdProduct);
                    Stock st = db.Stocks.Single(x => x.IdProduct == pd.Id && x.IdDeposit == espC.IdDeposit);

                    EntSalProductDAO espDAO = new EntSalProductDAO();
                    StockDB dbDAO = new StockDB();

                    //pregunta si es entrada o salida
                    if (espC.IdEntSalType == 1) //si es entrada
                    {
                        if (esp.Quantity <= st.Quantity)
                        {
                            //actualiza el costo de la cabecera
                            espDAO.Editar(esp.IdEntSalProduct, new EntSalProduct() { IdDeposit = espC.IdDeposit, IdEmployee = espC.IdEmployee, IdEntSalType = espC.IdEntSalType, Reason = espC.Reason, EntSalNumber = espC.EntSalNumber, DateP = espC.DateP, TotalCost = espC.TotalCost - esp.TotalCost });
                            //se actualiza el stock
                            dbDAO.Editar(st.Id, new Stock { IdProduct = pd.Id, IdDeposit = espC.IdDeposit, Quantity = st.Quantity - esp.Quantity });
                            db.EntSalProductDetails.Remove(esp);
                            db.SaveChanges();
                            return true;
                        }
                        else return false;
                    }
                    if (espC.IdEntSalType == 2)//si es salida
                    {
                        //actualiza el costo de la cabecera
                        espDAO.Editar(esp.IdEntSalProduct, new EntSalProduct() { IdDeposit = espC.IdDeposit, IdEmployee = espC.IdEmployee, IdEntSalType = espC.IdEntSalType, Reason = espC.Reason, EntSalNumber = espC.EntSalNumber, DateP = espC.DateP, TotalCost = espC.TotalCost - esp.TotalCost });
                        //se actualiza el stock
                        dbDAO.Editar(st.Id, new Stock { IdProduct = pd.Id, IdDeposit = espC.IdDeposit, Quantity = st.Quantity + esp.Quantity });
                        db.EntSalProductDetails.Remove(esp);
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
        public bool Editar(int id, EntSalProductDetail esp)
        {
            try
            {
                using (var db  = new AxureContext())
                {
                    int cantAux = esp.Quantity;

                    EntSalProduct espC = db.EntSalProducts.Single(x => x.Id == esp.IdEntSalProduct);
                    Product pd = db.Products.Single(x => x.Id == esp.IdProduct);
                    Stock st = db.Stocks.Single(x => x.IdProduct == pd.Id && x.IdDeposit == espC.IdDeposit);

                    StockDB dbDAO = new StockDB();

                    if (esp.Quantity <= st.Quantity)
                    {
                        EntSalProductDetail espD = db.EntSalProductDetails.FirstOrDefault(x => x.Id == id);
                        espD.IdEntSalProduct = esp.IdEntSalProduct;
                        espD.IdProduct = esp.IdProduct;
                        espD.Observation = esp.Observation;
                        espD.Quantity = esp.Quantity;
                        espD.TotalCost = esp.TotalCost;

                        //se actualiza el stock
                        dbDAO.Editar(st.Id, new Stock { IdProduct = pd.Id, IdDeposit = espC.IdDeposit, Quantity = st.Quantity - cantAux + esp.Quantity });

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