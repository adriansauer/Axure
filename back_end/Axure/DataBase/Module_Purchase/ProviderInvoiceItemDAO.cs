using Axure.DTO.Module_Purchase;
using Axure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Purchase
{
    public class ProviderInvoiceItemDAO
    {
        private readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<ProviderInvoiceItemDTO> ListByMaster(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var ls = db.ProviderInvoiceItems.Include("Provider").Where(x => x.ProviderInvoiceId == id)
                       .Select(x => new { Id = x.Id, ProductId = x.ProductId, ProductName = x.ProductName, PriceUnit = x.PriceUnit, Quantity = x.Quantity, Total = x.Total, TaxQuantity = x.TaxQuantity, TaxTotal = x.TaxTotal, ReturndQuantity = x.ReturndQuantity})
                       .ToList()
                       .Select(y => new ProviderInvoiceItemDTO { Id = y.Id, ProductId = y.ProductId, ProductName = y.ProductName, PriceUnit = y.PriceUnit, Quantity = y.Quantity, Total = y.Total, TaxQuantity = y.TaxQuantity, TaxTotal = y.TaxTotal, ReturndQuantity = y.ReturndQuantity })
                       .ToList();
                    return ls;
                }
            }
            catch (Exception e)
            {
                log.Error("Error al obtener listado de detalles de Facturas en ProviderInvoiceItemDAO" + e.Message + e.StackTrace);
                return null;
            }
        }
    }
}