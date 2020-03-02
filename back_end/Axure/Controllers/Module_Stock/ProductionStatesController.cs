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
    public class ProductionStatesController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/ProductionStates
        public IQueryable<ProductionState> GetProductionStates()
        {
            return db.ProductionStates;
        }

        // GET: api/ProductionStates/5
        [ResponseType(typeof(ProductionState))]
        public async Task<IHttpActionResult> GetProductionState(int id)
        {
            ProductionState productionState = await db.ProductionStates.FindAsync(id);
            if (productionState == null)
            {
                return NotFound();
            }

            return Ok(productionState);
        }

        // PUT: api/ProductionStates/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductionState(int id, ProductionState productionState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productionState.Id)
            {
                return BadRequest();
            }

            db.Entry(productionState).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionStateExists(id))
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

        // POST: api/ProductionStates
        [ResponseType(typeof(ProductionState))]
        public async Task<IHttpActionResult> PostProductionState(ProductionState productionState)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductionStates.Add(productionState);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productionState.Id }, productionState);
        }

        // DELETE: api/ProductionStates/5
        [ResponseType(typeof(ProductionState))]
        public async Task<IHttpActionResult> DeleteProductionState(int id)
        {
            ProductionState productionState = await db.ProductionStates.FindAsync(id);
            if (productionState == null)
            {
                return NotFound();
            }

            db.ProductionStates.Remove(productionState);
            await db.SaveChangesAsync();

            return Ok(productionState);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductionStateExists(int id)
        {
            return db.ProductionStates.Count(e => e.Id == id) > 0;
        }
    }
}