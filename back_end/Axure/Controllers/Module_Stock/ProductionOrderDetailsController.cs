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
    public class ProductionOrderDetailsController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/ProductionOrderDetails
        public IQueryable<ProductionOrderDetail> GetProductionOrderDetails()
        {
            return db.ProductionOrderDetails;
        }

        // GET: api/ProductionOrderDetails/5
        [ResponseType(typeof(ProductionOrderDetail))]
        public async Task<IHttpActionResult> GetProductionOrderDetail(int id)
        {
            ProductionOrderDetail productionOrderDetail = await db.ProductionOrderDetails.FindAsync(id);
            if (productionOrderDetail == null)
            {
                return NotFound();
            }

            return Ok(productionOrderDetail);
        }

        // PUT: api/ProductionOrderDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductionOrderDetail(int id, ProductionOrderDetail productionOrderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productionOrderDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(productionOrderDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductionOrderDetailExists(id))
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

        // POST: api/ProductionOrderDetails
        [ResponseType(typeof(ProductionOrderDetail))]
        public async Task<IHttpActionResult> PostProductionOrderDetail(ProductionOrderDetail productionOrderDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductionOrderDetails.Add(productionOrderDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productionOrderDetail.Id }, productionOrderDetail);
        }

        // DELETE: api/ProductionOrderDetails/5
        [ResponseType(typeof(ProductionOrderDetail))]
        public async Task<IHttpActionResult> DeleteProductionOrderDetail(int id)
        {
            ProductionOrderDetail productionOrderDetail = await db.ProductionOrderDetails.FindAsync(id);
            if (productionOrderDetail == null)
            {
                return NotFound();
            }

            db.ProductionOrderDetails.Remove(productionOrderDetail);
            await db.SaveChangesAsync();

            return Ok(productionOrderDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductionOrderDetailExists(int id)
        {
            return db.ProductionOrderDetails.Count(e => e.Id == id) > 0;
        }
    }
}