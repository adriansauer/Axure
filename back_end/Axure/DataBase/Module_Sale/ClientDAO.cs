using Axure.DTO.Module_Sale;
using Axure.Models;
using Axure.Models.Module_Sale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ClientDAO class
 * Created May 18, 2020 by Victor Ciceia.
 */
namespace Axure.DataBase.Module_Sale
{
    public class ClientDAO
    {
        public ClientDAO()
        {
        }

        public List<ClientDTO> GetAll()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var respuesta = db.Clients.Where(x => x.Deleted == false)
                        .Select(x => new { Id = x.Id, Name = x.Name, Address = x.Address, Phone = x.Phone, RUC = x.RUC, CreditMaximum = x.CreditMaximum, CreditPending = x.CreditPending })
                        .ToList()
                        .Select(y => new ClientDTO() { Id = y.Id, Name = y.Name, Address = y.Address, Phone = y.Phone, RUC = y.RUC, CreditMaximum = y.CreditMaximum, CreditPending = y.CreditPending })
                        .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public ClientDTO Detail(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var client = db.Clients.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    return new ClientDTO() { Id = client.Id, Name = client.Name, Address = client.Address, Phone = client.Phone, RUC = client.RUC, CreditMaximum = client.CreditMaximum, CreditPending = client.CreditPending };
                }
            }
            catch
            {
                return null;
            }
        }

        public bool Add(ClientDTO c)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.Clients.Add(new Client { Name = c.Name, Address = c.Address,Phone = c.Phone, RUC = c.RUC, CreditMaximum = c.CreditMaximum, CreditPending = 0, Deleted = false });
                    db.SaveChanges();
                    return false;
                }
            }
            catch
            {
                return true;
            }
        }

        public bool Edit(int id, ClientDTO c)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Client clienEditado = db.Clients.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    clienEditado.Name = c.Name;
                    clienEditado.Address = c.Address;
                    clienEditado.RUC = c.RUC;
                    clienEditado.CreditMaximum = c.CreditMaximum;
                    clienEditado.Phone = c.Phone;
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
                    Client client = db.Clients.FirstOrDefault(x => x.Id == id);
                    client.Deleted = true;
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
                    Client client = db.Clients.Single(x => x.Id == id);
                    if (null == client) { return true; }
                    db.Clients.Remove(client);
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