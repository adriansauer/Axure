using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Stock
{
    public class DepositDB
    {
        public DepositDB()
        {
        }

        /*
         * Metodo ObtenerTodosProductos, retorna todos los productos que tiene registrado.
        */
        public List<DepositDTO> ObtenerTodosLosDepositos()
        {
            try
            {
                using (var db = new AxureContext())
                {

                    var respuesta = db.Deposits.Where(x => x.Delete == false)
                        .Select(x => new { Id = x.Id, NameD = x.NameD})
                        .ToList()
                        .Select(y => new DepositDTO() { Id = y.Id, NameD = y.NameD})
                        .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public DepositDTO DetalleDelDeposito(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var d = db.Deposits.FirstOrDefault(x => x.Id == id && x.Delete == false);
                    return new DepositDTO() { Id = d.Id, NameD = d.NameD};
                }
            }
            catch
            {
                return null;
            }

        }


        public bool Agregar(DepositDTO d)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.Deposits.Add(new Deposit { NameD = d.NameD, Code = d.Code , Delete = false });
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }


        public bool Editar(int id, DepositDTO d)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Deposit depEditado = db.Deposits.FirstOrDefault(x => x.Id == id && x.Delete == false);
                    depEditado.NameD = d.NameD;
                    depEditado.Code = d.Code;
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool darDeBaja(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Deposit d = db.Deposits.FirstOrDefault(x => x.Id == id && x.Delete == false);
                    d.Delete = true;
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Deposit d = db.Deposits.Single(x => x.Id == id && x.Delete == false);
                    if (null == d) { return true; }
                    db.Deposits.Remove(d);
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