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
    public class MovementDetailsController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/MovementDetails
        public IQueryable<MovementDetail> GetMovementDetails()
        {
            return db.MovementDetails;
        }

        // GET: api/MovementDetails/5
        [ResponseType(typeof(MovementDetail))]
        public async Task<IHttpActionResult> GetMovementDetail(int id)
        {
            MovementDetail movementDetail = await db.MovementDetails.FindAsync(id);
            if (movementDetail == null)
            {
                return NotFound();
            }

            return Ok(movementDetail);
        }

        // PUT: api/MovementDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMovementDetail(int id, MovementDetail movementDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movementDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(movementDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovementDetailExists(id))
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

        // POST: api/MovementDetails
        [ResponseType(typeof(MovementDetail))]
        public async Task<IHttpActionResult> PostMovementDetail(MovementDetail movementDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MovementDetails.Add(movementDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = movementDetail.Id }, movementDetail);
        }

        // DELETE: api/MovementDetails/5
        [ResponseType(typeof(MovementDetail))]
        public async Task<IHttpActionResult> DeleteMovementDetail(int id)
        {
            MovementDetail movementDetail = await db.MovementDetails.FindAsync(id);
            if (movementDetail == null)
            {
                return NotFound();
            }

            db.MovementDetails.Remove(movementDetail);
            await db.SaveChangesAsync();

            return Ok(movementDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovementDetailExists(int id)
        {
            return db.MovementDetails.Count(e => e.Id == id) > 0;
        }
    }
}