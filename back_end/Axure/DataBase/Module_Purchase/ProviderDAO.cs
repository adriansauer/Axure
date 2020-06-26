using Axure.DTO.Module_Purchase;
using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Purchase
{
    public class ProviderDAO
    {
        public List<ProviderDTO> GetAll()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var respuesta = db.Providers.Where(x => x.Deleted == false)
                        .Select(x => new { Id = x.Id, Name = x.Name, Address = x.Address, Phone = x.Phone, RUC = x.RUC, Credit = x.Credit })
                        .ToList()
                        .Select(y => new ProviderDTO() { Id = y.Id, Name = y.Name, Address = y.Address, Phone = y.Phone, RUC = y.RUC, Credit = y.Credit })
                        .ToList();
                    return respuesta;
                }
            }
            catch
            {
                return null;
            }
        }

        public ProviderListDetailDTO Detail(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var provider = db.Providers.FirstOrDefault(x => x.Id == id && x.Deleted == false);
                    List<ProviderDetail> listDetails = db.ProviderDetails.Include("ProductCategory").Where(x => x.ProviderId == provider.Id).ToList();
                    List<ProviderDetailDTO> ListCategories = new List<ProviderDetailDTO>();
                    listDetails.ForEach(x => ListCategories.Add(new ProviderDetailDTO { Id = x.Id, Category = new ProductCategoryDTO { Id = x.ProductCategory.Id, Description = x.ProductCategory.Description} }));
                    ProviderListDetailDTO details = new ProviderListDetailDTO {
                        Id = provider.Id,
                        Name = provider.Name,
                        Address = provider.Address,
                        Phone = provider.Phone,
                        RUC = provider.RUC,
                        Credit = provider.Credit,
                        ListCategories = ListCategories
                    };
                    return details;
                }
            }
            catch
            {
                return null;
            }
        }
        /*
                public bool Add(ClientDTO c)
                {
                    try
                    {
                        using (var db = new AxureContext())
                        {
                            db.Clients.Add(new Client { Name = c.Name, Address = c.Address, Phone = c.Phone, RUC = c.RUC, CreditMaximum = c.CreditMaximum, CreditPending = 0, Deleted = false });
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
                }*/
    }
}