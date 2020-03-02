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
    public class MovementMotivesController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/MovementMotives
        public IQueryable<MovementMotive> GetMovementMotives()
        {
            return db.MovementMotives;
        }

        // GET: api/MovementMotives/5
        [ResponseType(typeof(MovementMotive))]
        public async Task<IHttpActionResult> GetMovementMotive(int id)
        {
            MovementMotive movementMotive = await db.MovementMotives.FindAsync(id);
            if (movementMotive == null)
            {
                return NotFound();
            }

            return Ok(movementMotive);
        }

        // PUT: api/MovementMotives/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMovementMotive(int id, MovementMotive movementMotive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movementMotive.Id)
            {
                return BadRequest();
            }

            db.Entry(movementMotive).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovementMotiveExists(id))
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

        // POST: api/MovementMotives
        [ResponseType(typeof(MovementMotive))]
        public async Task<IHttpActionResult> PostMovementMotive(MovementMotive movementMotive)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MovementMotives.Add(movementMotive);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = movementMotive.Id }, movementMotive);
        }

        // DELETE: api/MovementMotives/5
        [ResponseType(typeof(MovementMotive))]
        public async Task<IHttpActionResult> DeleteMovementMotive(int id)
        {
            MovementMotive movementMotive = await db.MovementMotives.FindAsync(id);
            if (movementMotive == null)
            {
                return NotFound();
            }

            db.MovementMotives.Remove(movementMotive);
            await db.SaveChangesAsync();

            return Ok(movementMotive);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovementMotiveExists(int id)
        {
            return db.MovementMotives.Count(e => e.Id == id) > 0;
        }
    }
}