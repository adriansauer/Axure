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
    public class ProductTypesController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/ProductTypes
        public IQueryable<ProductType> GetProductTypes()
        {
            return db.ProductTypes;
        }

        // GET: api/ProductTypes/5
        [ResponseType(typeof(ProductType))]
        public async Task<IHttpActionResult> GetProductType(int id)
        {
            ProductType productType = await db.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            return Ok(productType);
        }

        // PUT: api/ProductTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductType(int id, ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productType.Id)
            {
                return BadRequest();
            }

            db.Entry(productType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeExists(id))
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

        // POST: api/ProductTypes
        [ResponseType(typeof(ProductType))]
        public async Task<IHttpActionResult> PostProductType(ProductType productType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductTypes.Add(productType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productType.Id }, productType);
        }

        // DELETE: api/ProductTypes/5
        [ResponseType(typeof(ProductType))]
        public async Task<IHttpActionResult> DeleteProductType(int id)
        {
            ProductType productType = await db.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            db.ProductTypes.Remove(productType);
            await db.SaveChangesAsync();

            return Ok(productType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductTypeExists(int id)
        {
            return db.ProductTypes.Count(e => e.Id == id) > 0;
        }
    }
}