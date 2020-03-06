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
    public class StocksController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/Stocks
        public IQueryable<Stock> GetStocks()
        {
            return db.Stocks;
        }

        // GET: api/Stocks/5
        [ResponseType(typeof(Stock))]
        public async Task<IHttpActionResult> GetStock(int id)
        {
            Stock stock = await db.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }

        // PUT: api/Stocks/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStock(int id, Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stock.Id)
            {
                return BadRequest();
            }

            db.Entry(stock).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockExists(id))
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

        // POST: api/Stocks
        [ResponseType(typeof(Stock))]
        public async Task<IHttpActionResult> PostStock(Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stocks.Add(stock);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = stock.Id }, stock);
        }

        // DELETE: api/Stocks/5
        [ResponseType(typeof(Stock))]
        public async Task<IHttpActionResult> DeleteStock(int id)
        {
            Stock stock = await db.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            db.Stocks.Remove(stock);
            await db.SaveChangesAsync();

            return Ok(stock);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StockExists(int id)
        {
            return db.Stocks.Count(e => e.Id == id) > 0;
        }
    }
}