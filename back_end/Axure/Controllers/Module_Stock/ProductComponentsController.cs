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
    public class ProductComponentsController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/ProductComponents
        public IQueryable<ProductComponent> GetProductComponents()
        {
            return db.ProductComponents;
        }

        // GET: api/ProductComponents/5
        [ResponseType(typeof(ProductComponent))]
        public async Task<IHttpActionResult> GetProductComponent(int id)
        {
            ProductComponent productComponent = await db.ProductComponents.FindAsync(id);
            if (productComponent == null)
            {
                return NotFound();
            }

            return Ok(productComponent);
        }

        // PUT: api/ProductComponents/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductComponent(int id, ProductComponent productComponent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productComponent.Id)
            {
                return BadRequest();
            }

            db.Entry(productComponent).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductComponentExists(id))
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

        // POST: api/ProductComponents
        [ResponseType(typeof(ProductComponent))]
        public async Task<IHttpActionResult> PostProductComponent(ProductComponent productComponent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductComponents.Add(productComponent);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productComponent.Id }, productComponent);
        }

        // DELETE: api/ProductComponents/5
        [ResponseType(typeof(ProductComponent))]
        public async Task<IHttpActionResult> DeleteProductComponent(int id)
        {
            ProductComponent productComponent = await db.ProductComponents.FindAsync(id);
            if (productComponent == null)
            {
                return NotFound();
            }

            db.ProductComponents.Remove(productComponent);
            await db.SaveChangesAsync();

            return Ok(productComponent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductComponentExists(int id)
        {
            return db.ProductComponents.Count(e => e.Id == id) > 0;
        }
    }
}