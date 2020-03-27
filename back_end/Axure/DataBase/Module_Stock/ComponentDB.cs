using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Stock
{
    public class ComponentDB
    {
        public bool agregar(ProductComponent componente)
        {
            try
            {
                using (var db = new AxureContext())
                {                 
                    db.ProductComponents.Add(componente);             
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