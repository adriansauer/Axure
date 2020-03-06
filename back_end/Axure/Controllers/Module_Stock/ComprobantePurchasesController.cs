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
    public class ComprobantePurchasesController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/ComprobantePurchases
        public IQueryable<ComprobantePurchase> GetComprobantePurchases()
        {
            return db.ComprobantePurchases;
        }

        // GET: api/ComprobantePurchases/5
        [ResponseType(typeof(ComprobantePurchase))]
        public async Task<IHttpActionResult> GetComprobantePurchase(int id)
        {
            ComprobantePurchase comprobantePurchase = await db.ComprobantePurchases.FindAsync(id);
            if (comprobantePurchase == null)
            {
                return NotFound();
            }

            return Ok(comprobantePurchase);
        }

        // PUT: api/ComprobantePurchases/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutComprobantePurchase(int id, ComprobantePurchase comprobantePurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comprobantePurchase.Id)
            {
                return BadRequest();
            }

            db.Entry(comprobantePurchase).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComprobantePurchaseExists(id))
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

        // POST: api/ComprobantePurchases
        [ResponseType(typeof(ComprobantePurchase))]
        public async Task<IHttpActionResult> PostComprobantePurchase(ComprobantePurchase comprobantePurchase)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ComprobantePurchases.Add(comprobantePurchase);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = comprobantePurchase.Id }, comprobantePurchase);
        }

        // DELETE: api/ComprobantePurchases/5
        [ResponseType(typeof(ComprobantePurchase))]
        public async Task<IHttpActionResult> DeleteComprobantePurchase(int id)
        {
            ComprobantePurchase comprobantePurchase = await db.ComprobantePurchases.FindAsync(id);
            if (comprobantePurchase == null)
            {
                return NotFound();
            }

            db.ComprobantePurchases.Remove(comprobantePurchase);
            await db.SaveChangesAsync();

            return Ok(comprobantePurchase);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ComprobantePurchaseExists(int id)
        {
            return db.ComprobantePurchases.Count(e => e.Id == id) > 0;
        }
    }
}