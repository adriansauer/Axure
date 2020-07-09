using Axure.DataBase.Module_Stock;
using Axure.DTO.Module_Purchase;
using Axure.Models;
using Axure.Models.Module_Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Purchase
{
    public class ProviderInvoiceDAO
    {

        public List<ProviderInvoiceDTO> List()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var ls = db.ProviderInvoices
                        .Select(x => new { Id = x.Id, ProviderId = x.ProviderId, PurchaseOrderId = x.PurchaseOrderId, Status = x.Status, InvoiceNumber = x.InvoiceNumber, ProviderName = x.ProviderName, ProviderRUC = x.ProviderRUC, ProviderAddress = x.ProviderAddress, Date = x.Date, Total = x.Total, TaxTotal = x.TaxTotal })
                        .ToList()
                        .Select(y => new ProviderInvoiceDTO { Id = y.Id, ProviderId = y.ProviderId, PurchaseOrderId = y.PurchaseOrderId, Status = y.Status, InvoiceNumber = y.InvoiceNumber, ProviderName = y.ProviderName, ProviderRUC = y.ProviderRUC, ProviderAddress = y.ProviderAddress, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, Total = y.Total, TaxTotal = y.TaxTotal })
                        .ToList();
                    return ls;
                }
            }
            catch (Exception e)
            {             
                return null;
            }
        }

        public List<string> GetAllStatus()
        {
            try
            {
                List<string> status = new List<string>();
                foreach (string i in Enum.GetNames(typeof(StatusInvoice)))
                    status.Add(i);
                return status;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<string> GetAllSaleCondition()
        {
            try
            {
                List<string> status = new List<string>();
                foreach (string i in Enum.GetNames(typeof(SaleCondition)))
                    status.Add(i);
                return status;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<int> Add(PurchaseInvoiceDetailsDTO data)
        {

            using (var db = new AxureContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    List<int> ListProductError = new List<int>();
                    try
                    {
                        ProductDAO productDAO = new ProductDAO();
                        ProviderDAO providerDAO = new ProviderDAO();
                        ProviderListDetailDTO provider = providerDAO.Detail(data.ProviderId);
                        
                        //Create the invoice.
                        ProviderInvoice providerInvoice = new ProviderInvoice()
                        {
                            ProviderId = data.ProviderId,
                            PurchaseOrderId = data.PurchaseOrderId,
                            Status = StatusInvoice.Pagada.ToString(),
                            InvoiceNumber = data.InvoiceNumber,
                            ProviderName = provider.Name,
                            ProviderRUC = provider.RUC,
                            ProviderAddress = provider.Address,
                            Date = new DateTime(data.Year, data.Month, data.Day),
                            Total = 0,
                            TaxTotal = 0
                        };
                        db.ProviderInvoices.Add(providerInvoice);
                        db.SaveChanges();

                        //Add details.
                        if (null != data.ListItems)
                        {
                            for (int i = 0; i < data.ListItems.Count; i++)
                            {
                                int productId = data.ListItems[i].ProductId;
                                var producto = db.Products.Include("Tax").FirstOrDefault(x => x.Id == productId && x.Deleted == false);
                                ProviderInvoiceItem invoiceItem = new ProviderInvoiceItem()
                                {
                                    ProviderInvoiceId = providerInvoice.Id,
                                    ProductId = data.ListItems[i].ProductId,
                                    ProductName = producto.Name,
                                    PriceUnit = producto.Price,
                                    Quantity = data.ListItems[i].Quantity,
                                    Total = data.ListItems[i].Quantity * producto.Price,
                                    TaxQuantity = producto.Tax.Quantity,
                                    TaxTotal = 0
                                };
                                double tax = invoiceItem.Total - ((double)invoiceItem.Total / (((double)producto.Tax.Quantity / 100) + 1));
                                invoiceItem.TaxTotal = (int)tax;

                                db.ProviderInvoiceItems.Add(invoiceItem);
                                db.SaveChanges();

                                //Head modify.
                                providerInvoice.Total += invoiceItem.Total;
                                providerInvoice.TaxTotal += invoiceItem.TaxTotal;                           
                            }

                            //Modified of the order sale.
                            PurchaseOrderDAO purchaseOrderDAO = new PurchaseOrderDAO();
                            if (!purchaseOrderDAO.ModifyProductsQuantity(providerInvoice.PurchaseOrderId, data.ListItems))
                            {
                                throw new System.Exception();
                            }

                            //Modification of the stock.
                            StockDAO stockDAO = new StockDAO();
                            SettingDAO settingDAO = new SettingDAO();
                            if (stockDAO.IncreaseProductsQuantity(data.ListItems, int.Parse(settingDAO.Get("ID_DEPOSIT_RAW_MATERIAL"))))
                            {
                                throw new System.Exception();
                            }
                        }
                        db.SaveChanges();

                        //Everything went well.
                        dbContextTransaction.Commit();
                        return ListProductError;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        return ListProductError;
                    }
                    catch (Exception e)
                    {
                        dbContextTransaction.Rollback();
                        return null;
                    }
                }
            }

        }
    }

    public enum StatusInvoice
    {
        Pagada,
        Cancelada,
        Pendiente,
        Retrasada
    }

    public enum SaleCondition
    {
        Contado,
        Credito
    }
}