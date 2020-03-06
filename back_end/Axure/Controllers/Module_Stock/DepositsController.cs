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
    public class DepositsController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/Deposits
        public IQueryable<Deposit> GetDeposits()
        {
            return db.Deposits;
        }

        // GET: api/Deposits/5
        [ResponseType(typeof(Deposit))]
        public async Task<IHttpActionResult> GetDeposit(int id)
        {
            Deposit deposit = await db.Deposits.FindAsync(id);
            if (deposit == null)
            {
                return NotFound();
            }

            return Ok(deposit);
        }

        // PUT: api/Deposits/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDeposit(int id, Deposit deposit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deposit.Id)
            {
                return BadRequest();
            }

            db.Entry(deposit).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepositExists(id))
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

        // POST: api/Deposits
        [ResponseType(typeof(Deposit))]
        public async Task<IHttpActionResult> PostDeposit(Deposit deposit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Deposits.Add(deposit);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = deposit.Id }, deposit);
        }

        // DELETE: api/Deposits/5
        [ResponseType(typeof(Deposit))]
        public async Task<IHttpActionResult> DeleteDeposit(int id)
        {
            Deposit deposit = await db.Deposits.FindAsync(id);
            if (deposit == null)
            {
                return NotFound();
            }

            db.Deposits.Remove(deposit);
            await db.SaveChangesAsync();

            return Ok(deposit);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DepositExists(int id)
        {
            return db.Deposits.Count(e => e.Id == id) > 0;
        }
    }
}