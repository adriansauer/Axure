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
    public class MovementProductDAO
    {
        //Constructor
        /*public MovementProductDAO() { }

        //Agregar datos a la Cabecera de Entrada y Salida de Productos
        public bool Agregar(MovementProductionType esp)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.MovementProducts.Add(new MovementProductionType() { 
                        Number = esp.Number, 
                        Date = esp.Date,
                        TotalCost = esp.TotalCost,
                        Reason = esp.Reason,
                        DepositId = esp.DepositId,
                        EmployeeId = esp.EmployeeId,
                        MovementTypeId = esp.MovementTypeId});
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
                    MovementProductionType esp = db.MovementProducts.Single(x => x.Id == id);
                    if (null == esp) return true;

                    //Todos los detalles de una cabecera
                    var produc = db.MovementProductDetails
                        .Where(x => x.MovementProductId == esp.Id)
                        .ToList();

                    if (produc == null) return true;

                    //Elimina primero los detalles
                    for (int i = 0; i < produc.Count; i++)
                    {
                        db.MovementProductDetails.Remove(produc[i]);
                    }
                    //Luego elimina la cabecera
                    db.MovementProducts.Remove(esp);// db.EntSalProducts.Single(x=> x.Id == id));
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Editar(int id, MovementProductionType esp)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    MovementProductionType pr = db.MovementProducts.FirstOrDefault(x => x.Id == id);

                    pr.DepositId    = esp.DepositId;
                    pr.EmployeeId   = esp.EmployeeId;
                    pr.Reason       = esp.Reason;
                    //no deberia
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

        public List<MovementProductDTO> MovementDeposito(int deposito)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Deposit dp = db.Deposits.Single(x => x.Id == deposito);
                    var movement = db.MovementProducts.Where(x => x.DepositId == dp.Id).ToList();
                    List<MovementProductionType> lista = new List<MovementProductionType>();
                    movement.ForEach( x=> lista.Add(db.MovementProducts.Single(y => y.Id == x.Id)));

                    var listaMov = lista.Select(x => new { Id = x.Id, Number = x.Number, Date = x.Date, TotalCost = x.TotalCost, Reason = x.Reason, EmployeeId = x.EmployeeId, DepositId = x.DepositId, MovementTypeId = x.MovementTypeId })
                        .ToList()
                        .Select(y => new MovementProductDTO(){ Id = y.Id, Number = y.Number, Date = y.Date, TotalCost = y.TotalCost, Reason = y.Reason, EmployeeId = y.EmployeeId, DepositId = y.DepositId, MovementTypeId = y.MovementTypeId})
                        .ToList();
                    return listaMov;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<MovementProductDTO> Obtener()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var lista = db.MovementProducts.Where(x => x.TotalCost > 0)
                        .Select(x => new { Id = x.Id, Number = x.Number, Date = x.Date, TotalCost = x.TotalCost, Reason = x.Reason, EmployeeId = x.EmployeeId, DepositId = x.DepositId, MovementTypeId = x.MovementTypeId })
                        .ToList()
                        .Select(y => new MovementProductDTO { Id = y.Id, Number = y.Number, Date = y.Date, TotalCost = y.TotalCost, Reason = y.Reason, EmployeeId = y.EmployeeId, DepositId = y.DepositId, MovementTypeId = y.MovementTypeId })
                        .ToList();
                    return lista;
                }
            }
            catch
            {
                return null;
            }
        }
        */
    }
}