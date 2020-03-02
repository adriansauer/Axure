using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Axure.Models;
using Axure.Models.Module_Stock;

namespace Axure.Controllers.Module_Stock
{
    public class TransfersController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/Transfers
        public IQueryable<Transfer> GetTransfers()
        {
            return db.Transfers;
        }

        // GET: api/Transfers/5
        [ResponseType(typeof(Transfer))]
        public async Task<IHttpActionResult> GetTransfer(int id)
        {
            Transfer transfer = await db.Transfers.FindAsync(id);
            if (transfer == null)
            {
                return NotFound();
            }

            return Ok(transfer);
        }

        // PUT: api/Transfers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTransfer(int id, Transfer transfer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transfer.Id)
            {
                return BadRequest();
            }

            db.Entry(transfer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransferExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Transfers
        [ResponseType(typeof(Transfer))]
        public async Task<IHttpActionResult> PostTransfer(Transfer transfer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Transfers.Add(transfer);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = transfer.Id }, transfer);
        }

        // DELETE: api/Transfers/5
        [ResponseType(typeof(Transfer))]
        public async Task<IHttpActionResult> DeleteTransfer(int id)
        {
            Transfer transfer = await db.Transfers.FindAsync(id);
            if (transfer == null)
            {
                return NotFound();
            }

            db.Transfers.Remove(transfer);
            await db.SaveChangesAsync();

            return Ok(transfer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransferExists(int id)
        {
            return db.Transfers.Count(e => e.Id == id) > 0;
        }
    }
}