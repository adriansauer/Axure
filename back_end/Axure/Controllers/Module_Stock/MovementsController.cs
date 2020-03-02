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
    public class MovementsController : ApiController
    {
        private AxureContext db = new AxureContext();

        // GET: api/Movements
        public IQueryable<Movement> GetMovements()
        {
            return db.Movements;
        }

        // GET: api/Movements/5
        [ResponseType(typeof(Movement))]
        public async Task<IHttpActionResult> GetMovement(int id)
        {
            Movement movement = await db.Movements.FindAsync(id);
            if (movement == null)
            {
                return NotFound();
            }

            return Ok(movement);
        }

        // PUT: api/Movements/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMovement(int id, Movement movement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movement.Id)
            {
                return BadRequest();
            }

            db.Entry(movement).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovementExists(id))
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

        // POST: api/Movements
        [ResponseType(typeof(Movement))]
        public async Task<IHttpActionResult> PostMovement(Movement movement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movements.Add(movement);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = movement.Id }, movement);
        }

        // DELETE: api/Movements/5
        [ResponseType(typeof(Movement))]
        public async Task<IHttpActionResult> DeleteMovement(int id)
        {
            Movement movement = await db.Movements.FindAsync(id);
            if (movement == null)
            {
                return NotFound();
            }

            db.Movements.Remove(movement);
            await db.SaveChangesAsync();

            return Ok(movement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovementExists(int id)
        {
            return db.Movements.Count(e => e.Id == id) > 0;
        }
    }
}