using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;

namespace Axure.DataBase.Module_Stock
{
    public class TransferDetailDAO
    {
        StockDAO stDAO = new StockDAO();
        Transfer tc;
        Stock stOri;
        Stock stDes;

        //Agregar a la tabla
        public bool Add(TransferDetail td)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    //cabecera de la transferencia
                    tc = db.Transfers.Single(x => x.Id == td.TransferId && x.Number == td.Number);

                    //Stock de depositos de Origen y destino
                    try
                    {
                        //trata de encontar el deposito de origen del producto a transferir, si encuentra, perfecto
                        stOri = db.Stocks.Single(x => x.DepositId == tc.DepositOriginId && x.ProductId == td.ProductId);
                    }
                    catch
                    {
                        //si no encuentra retorna false y corta el agregado
                        return false;
                    }
                    try
                    {
                        //trata de encontar el deposito de destino del producto a transferir, si encuentra, perfecto
                        stDes = db.Stocks.Single(x => x.DepositId == tc.DepositDestinationId && x.ProductId == td.ProductId);
                    }
                    catch
                    {
                        //si no encuentra, lo inicializa a null para pasar a crear un stock del producto a transferir
                        stDes = null;
                    }

                    
                    if (td.Quantity <= stOri.Quantity)//si la cantidad a transferir es menor o igual al stock actual entonces se realiza si no retorna false
                    {
                        if (stDes == null)//si es stock es nulo entonces crea uno nuevo
                        {
                            db.TransferDetails.Add(new TransferDetail { ProductId = td.ProductId, TransferId = td.TransferId, Quantity = td.Quantity, Deleted = td.Deleted, Number = td.Number });
                            stDAO.Add(new StockDTO { ProductId = td.ProductId, DepositId = tc.DepositDestinationId, Quantity = td.Quantity });
                            stDAO.UpdateQuantity(stOri, td.ProductId, stOri.Quantity - td.Quantity);
                        }
                        else//si el deposito de destino no es nulo entonces actualiza su cantidad
                        {
                            db.TransferDetails.Add(new TransferDetail { ProductId = td.ProductId, TransferId = td.TransferId, Quantity = td.Quantity, Deleted = td.Deleted, Number = td.Number });
                            stDAO.UpdateQuantity(stOri, td.ProductId, stOri.Quantity - td.Quantity);
                            stDAO.UpdateQuantity(stDes, td.ProductId, stDes.Quantity + td.Quantity);
                        }
                        db.SaveChanges();
                        return true;
                    }
                    else//retorna false si la cantidad a transferir supera la cantidad existente
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        //Lista todos los detalles de una tranferencia
        public List<TransferDetailDTO> ListDetailOfTransfer(int TransferId)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var tr = db.TransferDetails.Where(x => x.TransferId == TransferId).ToList();
                    List<TransferDetail> lsTr = new List<TransferDetail>();
                    tr.ForEach(x => lsTr.Add(db.TransferDetails.Single(y => x.Id == y.Id && y.Deleted == false)));
                    var transfers = lsTr
                        .Select(x => new { Id = x.Id, ProductId = x.ProductId, TransferId = x.TransferId, Quantity = x.Quantity, Deleted = x.Deleted, Number = x.Number })
                        .ToList()
                        .Select(y => new TransferDetailDTO { Id = y.Id, ProductId = y.ProductId, TransferId = y.TransferId, Quantity = y.Quantity, Deleted = y.Deleted, Number = y.Number })
                        .ToList();
                    return transfers;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}