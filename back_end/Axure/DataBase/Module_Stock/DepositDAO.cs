using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * DepositDAO class
 * Created april 20, 2020 by Victor Ciceia.
 */
namespace Axure.DataBase.Module_Stock
{
    public class DepositDAO
    {
        public DepositDAO()
        {
        }

        public List<Deposit> GetAll()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    return db.Deposits.ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public Deposit Detail(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    return db.Deposits.FirstOrDefault(x => x.Id == id );
                }
            }
            catch
            {
                return null;
            }

        }

        public bool Add(Deposit d)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.Deposits.Add(d);
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Edit(int id, Deposit d)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Deposit depEditado = db.Deposits.FirstOrDefault(x => x.Id == id);
                    depEditado.Name = d.Name;
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Deposit d = db.Deposits.Single(x => x.Id == id );
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