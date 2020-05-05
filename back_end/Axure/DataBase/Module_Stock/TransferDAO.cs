using Axure.DTO.Module_Stock;
using Axure.Models;
using Axure.Models.Module_Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Axure.DataBase.Module_Stock
{
    public class TransferDAO
    {
        //CONSTRUCTOR
        public TransferDAO() { }

        //Agregar datos a la cabecera de la transferencia
        public bool Add(TransferListDTO tc)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Transfer trC = new Transfer()
                    {
                        DepositDestinationId = tc.DepositDestinationId,
                        DepositOriginId = tc.DepositOriginId,
                        Date = new DateTime(tc.Year, tc.Month, tc.Day),
                        Observation = tc.Observation,
                        Deleted = false,
                        Number = 0
                    };
                    db.Transfers.Add(trC);
                    db.SaveChanges();
                    TransferDetailDAO trDAO = new TransferDetailDAO();
                    if (null != tc.ListDetails)
                    {
                        for (int i = 0; i < tc.ListDetails.Count; i++)
                        {
                            tc.ListDetails[i].TransferId = trC.Id;
                            trDAO.Add(tc.ListDetails[i]);
                        }
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        //listar todas las transferencias
        public List<TransferDTO> ListAll()
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var transfers = db.Transfers.Where(x => x.Deleted == false)
                        .Select(x => new { Id = x.Id, DepositOriginId = x.DepositOriginId, DepositDestinationId = x.DepositDestinationId, Date = x.Date, Observation = x.Observation})
                        .ToList()
                        .Select(y=> new TransferDTO { Id = y.Id, DepositOriginId = y.DepositOriginId, DepositDestinationId = y.DepositDestinationId, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, Observation = y.Observation})
                        .ToList();
                    return transfers;
                }
            }
            catch
            {
                return null;
            }
        }

        //listar por id de Tranferencia
        public TransferDTO ListMasterId(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var tr = db.Transfers.Single(x => x.Id == id);
                    return new TransferDTO() { Id = tr.Id, DepositOriginId = tr.DepositOriginId, DepositDestinationId = tr.DepositDestinationId, Day = tr.Date.Day, Month = tr.Date.Month, Year = tr.Date.Year, Observation = tr.Observation };
                }
            }
            catch
            {
                return null;
            }
        }

        //Lista todas las tranferencia con un deposito dado Origen
        public List<TransferDTO> ListDepositOrigin(int depositId)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var tr = db.Transfers.Where(x => x.DepositOriginId == depositId).ToList();
                    List<Transfer> lsTr = new List<Transfer>();
                    tr.ForEach(x=> lsTr.Add(db.Transfers.Single(y=> x.Id == y.Id && y.Deleted == false)));
                    var transfers = lsTr
                        .Select(x => new { Id = x.Id, DepositOriginId = x.DepositOriginId, DepositDestinationId = x.DepositDestinationId, Date = x.Date, Observation = x.Observation })
                        .ToList()
                        .Select(y => new TransferDTO { Id = y.Id, DepositOriginId = y.DepositOriginId, DepositDestinationId = y.DepositDestinationId, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, Observation = y.Observation })
                        .ToList();
                    return transfers;
                }
            }
            catch
            {
                return null;
            }
        }

        //Lista todas las tranferencia con un deposito dado Destino
        public List<TransferDTO> ListDepositDestination(int depositId)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    var tr = db.Transfers.Where(x => x.DepositDestinationId == depositId).ToList();
                    List<Transfer> lsTr = new List<Transfer>();
                    tr.ForEach(x => lsTr.Add(db.Transfers.Single(y => x.Id == y.Id && y.Deleted == false)));
                    var transfers = lsTr
                        .Select(x => new { Id = x.Id, DepositOriginId = x.DepositOriginId, DepositDestinationId = x.DepositDestinationId, Date = x.Date, Observation = x.Observation })
                        .ToList()
                        .Select(y => new TransferDTO { Id = y.Id, DepositOriginId = y.DepositOriginId, DepositDestinationId = y.DepositDestinationId, Day = y.Date.Day, Month = y.Date.Month, Year = y.Date.Year, Observation = y.Observation })
                        .ToList();
                    return transfers;
                }
            }
            catch
            {
                return null;
            }
        }

        //borrado ocioso
        public bool Remove(int id)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    Transfer bajar = db.Transfers.FirstOrDefault(x => x.Id == id);
                    bajar.Deleted = true;
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