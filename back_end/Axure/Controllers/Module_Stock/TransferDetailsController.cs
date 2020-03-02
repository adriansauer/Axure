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
    public class TransferDetailsController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/TransferDetails
        public IQueryable<TransferDetail> GetTransferDetails()
        {
            return db.TransferDetails;
        }

        // GET: api/TransferDetails/5
        [ResponseType(typeof(TransferDetail))]
        public async Task<IHttpActionResult> GetTransferDetail(int id)
        {
            TransferDetail transferDetail = await db.TransferDetails.FindAsync(id);
            if (transferDetail == null)
            {
                return NotFound();
            }

            return Ok(transferDetail);
        }

        // PUT: api/TransferDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTransferDetail(int id, TransferDetail transferDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transferDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(transferDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransferDetailExists(id))
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

        // POST: api/TransferDetails
        [ResponseType(typeof(TransferDetail))]
        public async Task<IHttpActionResult> PostTransferDetail(TransferDetail transferDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TransferDetails.Add(transferDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = transferDetail.Id }, transferDetail);
        }

        // DELETE: api/TransferDetails/5
        [ResponseType(typeof(TransferDetail))]
        public async Task<IHttpActionResult> DeleteTransferDetail(int id)
        {
            TransferDetail transferDetail = await db.TransferDetails.FindAsync(id);
            if (transferDetail == null)
            {
                return NotFound();
            }

            db.TransferDetails.Remove(transferDetail);
            await db.SaveChangesAsync();

            return Ok(transferDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TransferDetailExists(int id)
        {
            return db.TransferDetails.Count(e => e.Id == id) > 0;
        }
    }
}