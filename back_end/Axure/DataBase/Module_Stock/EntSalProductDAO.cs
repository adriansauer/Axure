using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

/*
 * Creado por Enzo Ramirez
 * 10/04/2020
 */

namespace Axure.DataBase.Module_Stock
{
    public class EntSalProductDAO
    {
        //Constructor
        public EntSalProductDAO() { }

        //Agregar datos a la Cabecera de Entrada y Salida de Productos
        public bool Agregar(EntSalProduct esp)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.EntSalProducts.Add(new EntSalProduct() { 
                        EntSalNumber = esp.EntSalNumber, 
                        DateP = esp.DateP,
                        TotalCost = esp.TotalCost,
                        Reason = esp.Reason,
                        IdDeposit = esp.IdDeposit,
                        IdEmployee = esp.IdEmployee,
                        IdEntSalType = esp.IdEntSalType});
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        
        //Eliminar una cabecera EntSalProduct
        public bool Eliminar(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    EntSalProduct esp = db.EntSalProducts.Single(x => x.Id == id);
                    if (null == esp) return true;

                    //Todos los detalles de una cabecera
                    var produc = db.EntSalProductDetails
                        .Where(x => x.IdEntSalProduct == esp.Id)
                        .ToList();

                    if (produc == null) return true;

                    //Elimina primero los detalles
                    for (int i = 0; i < produc.Count; i++)
                    {
                        db.EntSalProductDetails.Remove(produc[i]);
                    }
                    //Luego elimina la cabecera
                    db.EntSalProducts.Remove(esp);// db.EntSalProducts.Single(x=> x.Id == id));
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Editar(int id, EntSalProduct esp)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    EntSalProduct pr = db.EntSalProducts.FirstOrDefault(x => x.Id == id);

                    pr.IdDeposit    = esp.IdDeposit;
                    pr.IdEmployee   = esp.IdEmployee;
                    pr.Reason       = esp.Reason;
                    pr.TotalCost    = esp.TotalCost;

                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }        

        public List<EntSalProductDTO> EntSalDeposito(int deposito)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Deposit dp = db.Deposits.Single(x => x.Id == deposito);
                    var entSal = db.EntSalProducts.Where(x => x.IdDeposit == dp.Id).ToList();
                    List<EntSalProduct> lista = new List<EntSalProduct>();
                    entSal.ForEach( x=> lista.Add(db.EntSalProducts.Single(y => y.Id == x.Id)));

                    var listaEntSal = lista.Select(x => new { Id = x.Id, EntSalNumber = x.EntSalNumber, DateP = x.DateP, TotalCost = x.TotalCost, Reason = x.Reason, IdEmployee = x.IdEmployee, IdDeposit = x.IdDeposit, IdEntSalType = x.IdEntSalType })
                        .ToList()
                        .Select(y => new EntSalProductDTO(){ Id = y.Id, EntSalNumber = y.EntSalNumber, DateP = y.DateP, TotalCost = y.TotalCost, Reason = y.Reason, IdEmployee = y.IdEmployee, IdDeposit = y.IdDeposit, IdEntSalType = y.IdEntSalType})
                        .ToList();
                    return listaEntSal;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<EntSalProductDTO> Obtener()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var lista = db.EntSalProducts.Where(x => x.TotalCost > 0)
                        .Select(x => new { Id = x.Id, EntSalNumber = x.EntSalNumber, DateP = x.DateP, TotalCost = x.TotalCost, Reason = x.Reason, IdEmployee = x.IdEmployee, IdDeposit = x.IdDeposit, IdEntSalType = x.IdEntSalType })
                        .ToList()
                        .Select(y => new EntSalProductDTO { Id = y.Id, EntSalNumber = y.EntSalNumber, DateP = y.DateP, TotalCost = y.TotalCost, Reason = y.Reason, IdEmployee = y.IdEmployee, IdDeposit = y.IdDeposit, IdEntSalType = y.IdEntSalType })
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