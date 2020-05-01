﻿using Antlr.Runtime.Tree;
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
        public bool Add(MovementProduct esp)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.MovementProducts.Add(new MovementProduct()
                    {
                        Date = esp.Date,
                        //TotalCost = esp.TotalCost,
                        DepositId = esp.DepositId,
                        EmployeeId = esp.EmployeeId,
                        MovementMotiveId = esp.MovementMotiveId
                    });
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public List<MovementProductDTO> MovementByDeposit(int deposito)
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

        public List<MovementProductDTO> List()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var lista = db.MovementProducts.Where(x => x.TotalCost >= 0)
                        .Select(x => new { Id = x.Id, Date = x.Date, TotalCost = x.TotalCost, EmployeeId = x.EmployeeId, DepositId = x.DepositId, MovementMotiveId = x.MovementMotiveId })
                        .ToList()
                        .Select(y => new MovementProductDTO { Id = y.Id, Date = y.Date, TotalCost = y.TotalCost, EmployeeId = y.EmployeeId, DepositId = y.DepositId, MovementMotiveId = y.MovementMotiveId })
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
                    MovementProduct mv = db.MovementProducts.Single(x => x.Id == mvId);
                    return new MovementProductDTO { Id = mv.Id, Date = mv.Date, TotalCost = mv.TotalCost, EmployeeId = mv.EmployeeId, DepositId = mv.DepositId, MovementMotiveId = mv.MovementMotiveId };
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
                    var mv = db.MovementProducts.Where(x => x.MovementMotiveId == mvMotiveId).ToList();
                    List<MovementProduct> mvList = new List<MovementProduct>();
                    mv.ForEach(x => mvList.Add(db.MovementProducts.Single(y => y.Id == x.Id)));
                    var mvs = mvList
                        .Select(x => new { Id = x.Id, Date = x.Date, TotalCost = x.TotalCost, EmployeeId = x.EmployeeId, DepositId = x.DepositId, MovementMotiveId = x.MovementMotiveId })
                        .ToList()
                        .Select(y => new MovementProductDTO { Id = y.Id, Date = y.Date, TotalCost = y.TotalCost, EmployeeId = y.EmployeeId, DepositId = y.DepositId, MovementMotiveId = y.MovementMotiveId })
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
                                                 where mvT.Id == mvTypeId
                                                 select mv).ToList();
                    var mvList = mvs
                        .Select(x => new { Id = x.Id, Date = x.Date, TotalCost = x.TotalCost, EmployeeId = x.EmployeeId, DepositId = x.DepositId, MovementMotiveId = x.MovementMotiveId })
                        .ToList()
                        .Select(y => new MovementProductDTO { Id = y.Id, Date = y.Date, TotalCost = y.TotalCost, EmployeeId = y.EmployeeId, DepositId = y.DepositId, MovementMotiveId = y.MovementMotiveId })
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
        public bool UpdateTotalCost(int mpId, int tc)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    MovementProduct mp = db.MovementProducts.FirstOrDefault(x => x.Id == mpId);
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

    }
}