using Antlr.Runtime.Tree;
using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
        public MovementProductDAO() { }

        //Agregar datos a la Cabecera de Entrada y Salida de Productos
        public bool Add(MovementProductListDTO esp)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    MovementProduct mvp = new MovementProduct()
                    {
                        Date = new DateTime(esp.Year, esp.Month, esp.Day),
                        TotalCost = 0,
                        DepositId = esp.DepositId,
                        EmployeeId = esp.EmployeeId,
                        MovementMotiveId = esp.MovementMotiveId,
                        Deleted = false
                    };
                    db.MovementProducts.Add(mvp);
                    db.SaveChanges();

                    MovementProductDetailDAO mvDDAO = new MovementProductDetailDAO();
                    if(null != esp.ListDetails)
                    {
                        for (int i = 0; i < esp.ListDetails.Count; i++)
                        {
                            esp.ListDetails[i].MovementProductId = mvp.Id;
                            mvDDAO.Add(esp.ListDetails[i]);
                        }
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /*public List<MovementProductDTO> MovementByDeposit(int deposito)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Deposit dp = db.Deposits.Single(x => x.Id == deposito);
                    var movement = db.MovementProducts.Where(x => x.DepositId == dp.Id).ToList();
                    List<MovementProduct> lista = new List<MovementProduct>();
                    movement.ForEach(x => lista.Add(db.MovementProducts.Single(y => y.Id == x.Id)));

                    var listaMov = lista.Select(x => new { Id = x.Id, Date = x.Date, TotalCost = x.TotalCost, EmployeeId = x.EmployeeId, DepositId = x.DepositId, MovementMotiveId = x.MovementMotiveId })
                        .ToList()
                        .Select(y => new MovementProductDTO() { Id = y.Id, Date = y.Date, TotalCost = y.TotalCost, EmployeeId = y.EmployeeId, DepositId = y.DepositId, MovementMotiveId = y.MovementMotiveId })
                        .ToList();
                    return listaMov;
                }
            }
            catch
            {
                return null;
            }
        }
        */
        public List<MovementProductDTO> List()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var lista = db.MovementProducts.Where(x => x.Deleted == false)
                        .Select(x => new { Id = x.Id, Date = x.Date, TotalCost = x.TotalCost, EmployeeId = x.EmployeeId, DepositId = x.DepositId, MovementMotiveId = x.MovementMotiveId })
                        .ToList()
                        .Select(y => new MovementProductDTO { Id = y.Id, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, TotalCost = y.TotalCost, EmployeeId = y.EmployeeId, DepositId = y.DepositId, MovementMotiveId = y.MovementMotiveId })
                        .ToList();
                    return lista;
                }
            }
            catch
            {
                return null;
            }
        }

        //listar por Id
        public MovementProductDTO ListByMasterId(int mvId)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    MovementProduct mv = db.MovementProducts.Single(x => x.Id == mvId && x.Deleted == false);
                    return new MovementProductDTO { Id = mv.Id, Day = mv.Date.Day, Month = mv.Date.Month, Year = mv.Date.Year, TotalCost = mv.TotalCost, EmployeeId = mv.EmployeeId, DepositId = mv.DepositId, MovementMotiveId = mv.MovementMotiveId };
                }
            }
            catch
            {
                return null;
            }
        }

        //listar por Motivo de movimiento
        public List<MovementProductDTO> ListByMovementMotive(int mvMotiveId)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var mv = db.MovementProducts.Where(x => x.MovementMotiveId == mvMotiveId && x.Deleted == false).ToList();
                    List<MovementProduct> mvList = new List<MovementProduct>();
                    mv.ForEach(x => mvList.Add(db.MovementProducts.Single(y => y.Id == x.Id)));
                    var mvs = mvList
                        .Select(x => new { Id = x.Id, Date = x.Date, TotalCost = x.TotalCost, EmployeeId = x.EmployeeId, DepositId = x.DepositId, MovementMotiveId = x.MovementMotiveId })
                        .ToList()
                        .Select(y => new MovementProductDTO { Id = y.Id, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, TotalCost = y.TotalCost, EmployeeId = y.EmployeeId, DepositId = y.DepositId, MovementMotiveId = y.MovementMotiveId })
                        .ToList();
                        return mvs;
                }
            }
            catch
            {
                return null;
            }
        }

        //listar por tipo de movimiento
        public List<MovementProductDTO> ListByMovementType(int mvTypeId)
        {
            try
            {
                using(var db = new AxureContext())
                {
                    List<MovementProduct> mvs = (from mv in db.MovementProducts
                                                 join mvM in db.MovementMotives on mv.MovementMotiveId equals mvM.Id
                                                 join mvT in db.MovementTypes on mvM.MovementTypeId equals mvT.Id
                                                 where (mvT.Id == mvTypeId && mv.Deleted == false)
                                                 select mv).ToList();
                    var mvList = mvs
                        .Select(x => new { Id = x.Id, Date = x.Date, TotalCost = x.TotalCost, EmployeeId = x.EmployeeId, DepositId = x.DepositId, MovementMotiveId = x.MovementMotiveId })
                        .ToList()
                        .Select(y => new MovementProductDTO { Id = y.Id, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, TotalCost = y.TotalCost, EmployeeId = y.EmployeeId, DepositId = y.DepositId, MovementMotiveId = y.MovementMotiveId })
                        .ToList();
                    return mvList;     
                }
            }
            catch
            {
                return null;
            }
        }

        //actualizar el costo total
        public bool UpdateTotalCost(MovementProduct mvp, int tc)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    MovementProduct mp = db.MovementProducts.FirstOrDefault(x => x.Id == mvp.Id);
                    mp.TotalCost = tc;
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        //borrado ocioso
        public bool Remove(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    MovementProduct bajar = db.MovementProducts.FirstOrDefault(x => x.Id == id);
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
    }
}