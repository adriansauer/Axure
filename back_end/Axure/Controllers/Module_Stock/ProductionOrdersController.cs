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
    public class ProductionOrdersController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/ProductionOrders
        public IQueryable<ProductionOrder> GetProductionOrders()
        {
            return db.ProductionOrders;
        }

        // GET: api/ProductionOrders/5
        [ResponseType(typeof(ProductionOrder))]
        public async Task<IHttpActionResult> GetProductionOrder(int id)
        {
            ProductionOrder productionOrder = await db.ProductionOrders.FindAsync(id);
            if (productionOrder == null)
            {
                return NotFound();
            }

            return Ok(productionOrder);
        }

        // PUT: api/ProductionOrders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductionOrder(int id, ProductionOrder productionOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productionOrder.Id)
            {
                return BadRequest();
            }

            db.Entry(productionOrder).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionOrderExists(id))
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

        // POST: api/ProductionOrders
        [ResponseType(typeof(ProductionOrder))]
        public async Task<IHttpActionResult> PostProductionOrder(ProductionOrder productionOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductionOrders.Add(productionOrder);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productionOrder.Id }, productionOrder);
        }

        // DELETE: api/ProductionOrders/5
        [ResponseType(typeof(ProductionOrder))]
        public async Task<IHttpActionResult> DeleteProductionOrder(int id)
        {
            ProductionOrder productionOrder = await db.ProductionOrders.FindAsync(id);
            if (productionOrder == null)
            {
                return NotFound();
            }

            db.ProductionOrders.Remove(productionOrder);
            await db.SaveChangesAsync();

            return Ok(productionOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductionOrderExists(int id)
        {
            return db.ProductionOrders.Count(e => e.Id == id) > 0;
        }
    }
}