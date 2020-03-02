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
    public class TransferTypesController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/TransferTypes
        public IQueryable<TransferType> GetTransferTypes()
        {
            return db.TransferTypes;
        }

        // GET: api/TransferTypes/5
        [ResponseType(typeof(TransferType))]
        public async Task<IHttpActionResult> GetTransferType(int id)
        {
            TransferType transferType = await db.TransferTypes.FindAsync(id);
            if (transferType == null)
            {
                return NotFound();
            }

            return Ok(transferType);
        }

        // PUT: api/TransferTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTransferType(int id, TransferType transferType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transferType.Id)
            {
                return BadRequest();
            }

            db.Entry(transferType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransferTypeExists(id))
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

        // POST: api/TransferTypes
        [ResponseType(typeof(TransferType))]
        public async Task<IHttpActionResult> PostTransferType(TransferType transferType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TransferTypes.Add(transferType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = transferType.Id }, transferType);
        }

        // DELETE: api/TransferTypes/5
        [ResponseType(typeof(TransferType))]
        public async Task<IHttpActionResult> DeleteTransferType(int id)
        {
            TransferType transferType = await db.TransferTypes.FindAsync(id);
            if (transferType == null)
            {
                return NotFound();
            }

            db.TransferTypes.Remove(transferType);
            await db.SaveChangesAsync();

            return Ok(transferType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransferTypeExists(int id)
        {
            return db.TransferTypes.Count(e => e.Id == id) > 0;
        }
    }
}