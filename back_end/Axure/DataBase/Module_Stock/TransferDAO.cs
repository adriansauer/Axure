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
        public bool Add(Transfer tc)
        {
            try
            {
                using (var db = new AxureContext())
                {
                    db.Transfers.Add(new Transfer
                    {
                        DepositDestinationId = tc.DepositDestinationId,
                        DepositOriginId = tc.DepositOriginId,
                        Date = tc.Date,
                        Observation = tc.Observation,
                        Deleted = false,
                        Number = 0
                    });
                    db.SaveChanges();
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
                        .Select(x => new { Id = x.Id, DepositOriginId = x.DepositOriginId, DepositDestinationId = x.DepositDestinationId, Date = x.Date, Observation = x.Observation, Number = x.Number })
                        .ToList()
                        .Select(y=> new TransferDTO { Id = y.Id, DepositOriginId = y.DepositOriginId, DepositDestinationId = y.DepositDestinationId, Date = y.Date, Observation = y.Observation, Number = y.Number })
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
                    return new TransferDTO() { Id = tr.Id, DepositOriginId = tr.DepositOriginId, DepositDestinationId = tr.DepositDestinationId, Date = tr.Date, Observation = tr.Observation, Number = tr.Number };
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
                        .Select(x => new { Id = x.Id, DepositOriginId = x.DepositOriginId, DepositDestinationId = x.DepositDestinationId, Date = x.Date, Observation = x.Observation, Number = x.Number })
                        .ToList()
                        .Select(y => new TransferDTO { Id = y.Id, DepositOriginId = y.DepositOriginId, DepositDestinationId = y.DepositDestinationId, Date = y.Date, Observation = y.Observation, Number = y.Number })
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
                        .Select(x => new { Id = x.Id, DepositOriginId = x.DepositOriginId, DepositDestinationId = x.DepositDestinationId, Date = x.Date, Observation = x.Observation, Number = x.Number })
                        .ToList()
                        .Select(y => new TransferDTO { Id = y.Id, DepositOriginId = y.DepositOriginId, DepositDestinationId = y.DepositDestinationId, Date = y.Date, Observation = y.Observation, Number = y.Number })
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