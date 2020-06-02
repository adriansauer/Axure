using Axure.DataBase.Module_Stock;
using Axure.DTO;
using Axure.DTO.Module_Sale;
using Axure.DTO.Module_Sale.InvoiceIn;
using Axure.DTO.Module_Sale.InvoicePreCreation;
using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Sale;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Sale
{
    public class InvoiceDAO
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public List<InvoiceDTO> List()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var ls = db.Invoices.Include("OrderSales")
                        .Select(x => new { Id = x.Id, OrderSale = x.OrderSale, SaleCondition = x.SaleCondition, Status = x.Status, InvoiceNumber = x.InvoiceNumber, ClientName = x.ClientName, ClientRUC = x.ClientRUC, ClientAddress = x.ClientAddress, Date = x.Date, Total = x.Total, TaxTotal = x.TaxTotal })
                        .ToList()
                        .Select(y => new InvoiceDTO { Id = y.Id, OrderNumber = y.OrderSale.OrderNumber, SaleCondition = y.SaleCondition, Status = y.Status, InvoiceNumber = y.InvoiceNumber, ClientName = y.ClientName, ClientRUC = y.ClientRUC, ClientAddress = y.ClientAddress, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, Total = y.Total, TaxTotal = y.TaxTotal })
                        .ToList();
                    return ls;

                }
            }
            catch (Exception e)
            {
                log.Error("Error al obtener listado de ordenes List OrderSaleDAO");
                return null;
            }
        }

        //Ordenes por cliente
        /*public List<OrderSaleListDTO> ListByClient(int clId)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var os = db.OrderSales.Where(x => x.ClientId == clId && x.Deleted == false).ToList();
                    List<OrderSale> osList = new List<OrderSale>();
                    os.ForEach(x => osList.Add(db.OrderSales.Single(y => y.Id == x.Id)));
                    var osR = osList
                        .Select(x => new { Id = x.Id, ClientId = x.ClientId, Status = x.Status, EmployeeId = x.EmployeeId, OrderNumber = x.OrderNumber, Day = x.Date.Day, Month = x.Date.Month, Year = x.Date.Year })
                        .ToList()
                        .Select(y => new OrderSaleListDTO { Id = y.Id, ClientId = y.ClientId, Status = y.Status, EmployeeId = y.EmployeeId, OrderNumber = y.OrderNumber, Day = y.Day, Month = y.Month, Year = y.Year, ListDetails = osdDAO.ListByMaster(y.Id) })
                        .ToList();

                    return osR;
                }
            }
            catch (Exception e)
            {
                log.Error("Error al obtener listado de ordenes ListByClient " + e.Message + e.StackTrace);
                return null;
            }
        }

        //Ordenes por la cabecera
        public List<OrderSaleListDTO> ListByStatus(string status)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var os = db.OrderSales.Where(x => x.Status.Equals(status) && x.Deleted == false).ToList();
                    List<OrderSale> osList = new List<OrderSale>();
                    os.ForEach(x => osList.Add(db.OrderSales.Single(y => y.Id == x.Id)));

                    var osR = osList
                        .Select(x => new { Id = x.Id, ClientId = x.ClientId, Status = x.Status, EmployeeId = x.EmployeeId, OrderNumber = x.OrderNumber, Day = x.Date.Day, Month = x.Date.Month, Year = x.Date.Year })
                        .ToList()
                        .Select(y => new OrderSaleListDTO { Id = y.Id, ClientId = y.ClientId, Status = y.Status, EmployeeId = y.EmployeeId, OrderNumber = y.OrderNumber, Day = y.Day, Month = y.Month, Year = y.Year, ListDetails = osdDAO.ListByMaster(y.Id) })
                        .ToList();

                    return osR;
                }
            }
            catch (Exception e)
            {
                log.Error("Error al obtener listado de ordenes ListByState " + e.Message + e.StackTrace);
                return null;
            }
        }

        //orden por id
        public OrderSaleListDTO GetById(int Id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    OrderSale y = db.OrderSales.Find(Id);// Single(x => x.Id == Id && x.Deleted == false);
                    return new OrderSaleListDTO { Id = y.Id, ClientId = y.ClientId, Status = y.Status, EmployeeId = y.EmployeeId, OrderNumber = y.OrderNumber, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, ListDetails = osdDAO.ListByMaster(y.Id) };

                }
            }
            catch (Exception e)
            {
                log.Error("Error al mostrar el listado de orden de venta por Id. " + e.Message + e.StackTrace);
                return null;
            }
        }

        //orden por numero de orden
        public OrderSaleListDTO GetByNumber(string number)
        {
            try
            {
                using (var db = new AxureContext())
                {//preguntar por este comparacion entre cadenas de string
                    OrderSale y = db.OrderSales.FirstOrDefault(x => x.OrderNumber == number && x.Deleted == false);
                    return new OrderSaleListDTO { Id = y.Id, ClientId = y.ClientId, Status = y.Status, EmployeeId = y.EmployeeId, OrderNumber = y.OrderNumber, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, ListDetails = osdDAO.ListByMaster(y.Id) };
                }
            }
            catch (Exception e)
            {
                log.Error("Error al Mostrar orden de venta por numero de orden. " + e.Message + e.StackTrace);
                return null;
            }
        }*/

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
                log.Error("Error al Mostrar los estados de una factura. " + e.Message + e.StackTrace);
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
                log.Error("Error al Mostrar las condiciones de venta de una factura. " + e.Message + e.StackTrace);
                return null;
            }
        }

        public InvoiceOutPreCreationDTO Validate(InvoiceInPreCreationDTO inData)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    OrderSaleDAO orderSaleDAO = new OrderSaleDAO();
                    ClientDAO clientDAO = new ClientDAO();
                    EmployeeDAO employeeDAO = new EmployeeDAO();
                    OrderSaleListDTO orderSaleDTO = orderSaleDAO.GetById(inData.OrderSaleId);
                    ClientDTO clientDTO = clientDAO.Detail(orderSaleDTO.ClientId);
                    EmployeeDTO employeeDTO = employeeDAO.Detail(inData.EmployeeId);

                    InvoiceOutPreCreationDTO invoiceOutPreCreationDTO = new InvoiceOutPreCreationDTO()
                    {
                        OrderSaleNumber = orderSaleDTO.OrderNumber,
                        EmployeeDTO = employeeDTO,
                        ClientDTO = clientDTO,
                        SaleCondition = inData.SaleCondition,
                        InvoiceNumber = "",
                        ValidationCode = 0,
                        Day = inData.Day,
                        Month = inData.Month,
                        Year = inData.Year,
                        TaxTotal = 0,
                        Total = 0
                    };

                    //Verifier in the deposit sale.
                    StockDAO stockDAO = new StockDAO();
                    SettingDAO settingDAO = new SettingDAO();
                    List<int> notStockProduct = stockDAO.CheckStock(inData.ListItems, int.Parse(settingDAO.Get("ID_DEPOSIT_SALE")));

                    List<IncoiceItemPreCreationDTO> listItems = new List<IncoiceItemPreCreationDTO>();
                    ProductDAO productDAO = new ProductDAO();

                    foreach(ProductQuantityDTO item in inData.ListItems)
                    {
                        IncoiceItemPreCreationDTO invoiceItem = new IncoiceItemPreCreationDTO();
                        //Product exists in the order sale.
                        if (orderSaleDTO.ListDetails.Exists(x => x.ProductId == item.ProductId))
                        {
                            ProductDTO product = productDAO.Detail(item.ProductId);
                            invoiceItem.Name = product.Name;
                            invoiceItem.Description = product.Description;
                            invoiceItem.QuantitySale = item.Quantity;
                            invoiceItem.UnitPrice = product.Price;
                            invoiceItem.Total = item.Quantity * product.Price;
                            invoiceItem.TaxPercentage = product.TaxPercentage;
                            double tax = invoiceItem.Total - ((double)invoiceItem.Total / (((double)product.TaxPercentage / 100) + 1));
                            invoiceItem.Tax = (int)tax;
                            invoiceItem.Barcode = product.Barcode;
                            invoiceItem.CodeStatus = 0;

                            //Head modify.
                            invoiceOutPreCreationDTO.TaxTotal += invoiceItem.Tax;
                            invoiceOutPreCreationDTO.Total += invoiceItem.Total;

                            //Quantity order sale.
                            foreach (OrderSaleDetailDTO productOrder in orderSaleDTO.ListDetails)
                            {
                                if (productOrder.ProductId == item.ProductId)
                                {
                                    if(productOrder.QuantityPending < item.Quantity || item.Quantity < 0)
                                    {
                                        invoiceItem.CodeStatus = 2;
                                        invoiceOutPreCreationDTO.ValidationCode = 2;
                                    }
                                }
                            }

                            //Quantity in stock sale.
                            if(notStockProduct.Exists(x => x == item.ProductId))
                            {
                                invoiceItem.CodeStatus = 3;
                                invoiceOutPreCreationDTO.ValidationCode = 2;
                            }
                        }
                        else
                        {
                            invoiceItem.CodeStatus = 1;
                        }
                        listItems.Add(invoiceItem);
                    }

                    invoiceOutPreCreationDTO.ListItems = listItems;

                    if(invoiceOutPreCreationDTO.SaleCondition.Equals(SaleCondition.Credito.ToString()) && invoiceOutPreCreationDTO.Total > (clientDTO.CreditMaximum - clientDTO.CreditPending))
                    {
                        invoiceOutPreCreationDTO.ValidationCode = 1;
                    }
                    return invoiceOutPreCreationDTO;
                }
                

            }
            catch (Exception e)
            {
                return null;
            }
        }


        public List<int> Add(InvoiceInDTO data)
        {

            using (var db = new AxureContext())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    List<int> ListProductError = new List<int>();
                    try
                    {
                        //Verifications.
                        OrderSaleDetailDAO orderSaleDetailDAO = new OrderSaleDetailDAO();
                        List<int> listNotExitentProducts = verficationProducts(orderSaleDetailDAO.ListByMaster(data.OrderSaleId),data.ListItems);
                        if(listNotExitentProducts.Count > 0)
                        {
                            ListProductError = listNotExitentProducts;
                            throw new System.IndexOutOfRangeException();
                        }

                        ClientDAO clientDAO = new ClientDAO();
                        ProductDAO productDAO = new ProductDAO();
                        ClientDTO client = clientDAO.Detail(data.ClientId);

                        //Create the invoice.
                        Invoice invoice = new Invoice(){ 
                            OrderSaleId = data.OrderSaleId,
                            EmployeeId = data.EmployeeId,
                            ClientId = data.ClientId, 
                            SaleCondition = data.SaleCondition,
                            Status = data.Status,
                            InvoiceNumber = data.InvoiceNumber,
                            ClientName = client.Name,
                            ClientRUC = client.RUC,
                            ClientAddress = client.Address,
                            Date = new DateTime(data.Year, data.Month, data.Day),
                            Total = 0,
                            TaxTotal = 0};
                        db.Invoices.Add(invoice);
                        db.SaveChanges();

                        //Add details.
                        if (null != data.ListItems)
                        {
                            List<InvoiceTax> invoiceTaxes = new List<InvoiceTax>();
                            for (int i = 0; i < data.ListItems.Count; i++)
                            {
                                int productId = data.ListItems[i].ProductId;
                                var producto = db.Products.Include("Tax").FirstOrDefault(x => x.Id == productId && x.Deleted == false);
                                InvoiceItem invoiceItem = new InvoiceItem()
                                {
                                    InvoiceId = invoice.Id,
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

                                db.InvoiceItems.Add(invoiceItem);
                                db.SaveChanges();

                                //Head modify.
                                invoice.Total += invoiceItem.Total;
                                invoice.TaxTotal += invoiceItem.TaxTotal;

                                //Tax creation.
                                int index = searchTax(invoiceTaxes, producto.Tax.Quantity);
                                if(-1 == index)
                                {
                                    invoiceTaxes.Add(new InvoiceTax() { InvoiceId = invoice.Id, TaxId = producto.TaxId, Amount = invoiceItem.TaxTotal, TaxPercentage = producto.Tax.Quantity });
                                }
                                else
                                {
                                    invoiceTaxes[index].Amount += invoiceItem.TaxTotal;
                                }
                            }

                            //Modified of the order sale.
                            OrderSaleDAO orderSaleDAO = new OrderSaleDAO();
                            if (!orderSaleDAO.ModifyProductsQuantity(invoice.OrderSaleId, data.ListItems))
                            {
                                throw new System.Exception();
                            }

                            for (int i = 0; i < invoiceTaxes.Count; i++){
                                db.InvoiceTaxes.Add(invoiceTaxes[i]);
                            }

                            //Modification of the stock.
                            StockDAO stockDAO = new StockDAO();
                            SettingDAO settingDAO = new SettingDAO();
                            if (stockDAO.DecreaseProductsQuantity(data.ListItems, int.Parse(settingDAO.Get("ID_DEPOSIT_SALE"))))
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
                        log.Error("Error al agregar una factura!!!");
                        return null;
                    }
                }
            }

        }

        private List<int> verficationProducts(List<OrderSaleDetailDTO> listOrderDetails, List<ProductQuantityDTO> listInvoiceItems)
        {
            try
            {
                //Verifier in the order sale.
                OrderSaleDAO orderSaleDAO = new OrderSaleDAO();
                List<int> listNotExitentProducts;
                listNotExitentProducts = orderSaleDAO.verificationProductQuantity(listOrderDetails, listInvoiceItems);
                if (listNotExitentProducts.Count > 0)
                {
                    return listNotExitentProducts;
                }
                //Verifier in the deposit sale.
                StockDAO stockDAO = new StockDAO();
                SettingDAO settingDAO = new SettingDAO();
                listNotExitentProducts = stockDAO.CheckStock(listInvoiceItems, int.Parse(settingDAO.Get("ID_DEPOSIT_SALE")));
                return listNotExitentProducts;               
            }catch(Exception e)
            {
                return null;
            }         
        }

        private int searchTax(List<InvoiceTax> invoiceTaxes, int percentage)
        {
            for(int i = 0; i < invoiceTaxes.Count; i++)
            {
                if(percentage == invoiceTaxes[i].TaxPercentage)
                {
                    return i;
                }
            }
            return -1;
        }


        //cambiar estado
       /* public bool UpdateState(int osId, string status)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    OrderSale os = db.OrderSales.FirstOrDefault(x => x.Id == osId);
                    os.Status = status;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {
                log.Error("No se puede modificar el estado de la orden. " + e.Message + e.StackTrace);
                return false;
            }
        }
        */

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