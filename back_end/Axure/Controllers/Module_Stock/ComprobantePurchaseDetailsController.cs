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
    public class ComprobantePurchaseDetailsController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/ComprobantePurchaseDetails
        public IQueryable<ComprobantePurchaseDetail> GetComprobantePurchaseDetails()
        {
            return db.ComprobantePurchaseDetails;
        }

        // GET: api/ComprobantePurchaseDetails/5
        [ResponseType(typeof(ComprobantePurchaseDetail))]
        public async Task<IHttpActionResult> GetComprobantePurchaseDetail(int id)
        {
            ComprobantePurchaseDetail comprobantePurchaseDetail = await db.ComprobantePurchaseDetails.FindAsync(id);
            if (comprobantePurchaseDetail == null)
            {
                return NotFound();
            }

            return Ok(comprobantePurchaseDetail);
        }

        // PUT: api/ComprobantePurchaseDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComprobantePurchaseDetail(int id, ComprobantePurchaseDetail comprobantePurchaseDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comprobantePurchaseDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(comprobantePurchaseDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprobantePurchaseDetailExists(id))
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

        // POST: api/ComprobantePurchaseDetails
        [ResponseType(typeof(ComprobantePurchaseDetail))]
        public async Task<IHttpActionResult> PostComprobantePurchaseDetail(ComprobantePurchaseDetail comprobantePurchaseDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ComprobantePurchaseDetails.Add(comprobantePurchaseDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = comprobantePurchaseDetail.Id }, comprobantePurchaseDetail);
        }

        // DELETE: api/ComprobantePurchaseDetails/5
        [ResponseType(typeof(ComprobantePurchaseDetail))]
        public async Task<IHttpActionResult> DeleteComprobantePurchaseDetail(int id)
        {
            ComprobantePurchaseDetail comprobantePurchaseDetail = await db.ComprobantePurchaseDetails.FindAsync(id);
            if (comprobantePurchaseDetail == null)
            {
                return NotFound();
            }

            db.ComprobantePurchaseDetails.Remove(comprobantePurchaseDetail);
            await db.SaveChangesAsync();

            return Ok(comprobantePurchaseDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComprobantePurchaseDetailExists(int id)
        {
            return db.ComprobantePurchaseDetails.Count(e => e.Id == id) > 0;
        }
    }
}