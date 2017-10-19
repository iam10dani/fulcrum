using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Tendani.Models;

namespace Tendani.Controllers
{
    public class ToolUsedsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ToolUseds
        public IQueryable<ToolUsed> GetToolUseds()
        {
            return db.ToolUseds;
        }

        // GET: api/ToolUseds/5
        [ResponseType(typeof(ToolUsed))]
        public IHttpActionResult GetToolUsed(string id)
        {
            ToolUsed toolUsed = db.ToolUseds.Find(id);
            if (toolUsed == null)
            {
                return NotFound();
            }

            return Ok(toolUsed);
        }

        // PUT: api/ToolUseds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutToolUsed(string id, ToolUsed toolUsed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toolUsed.Id)
            {
                return BadRequest();
            }

            db.Entry(toolUsed).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToolUsedExists(id))
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

        // POST: api/ToolUseds
        [ResponseType(typeof(ToolUsed))]
        public IHttpActionResult PostToolUsed(ToolUsed toolUsed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            toolUsed.Id = Guid.NewGuid().ToString();
            db.ToolUseds.Add(toolUsed);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ToolUsedExists(toolUsed.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = toolUsed.Id }, toolUsed);
        }

        // DELETE: api/ToolUseds/5
        [ResponseType(typeof(ToolUsed))]
        public IHttpActionResult DeleteToolUsed(string id)
        {
            ToolUsed toolUsed = db.ToolUseds.Find(id);
            if (toolUsed == null)
            {
                return NotFound();
            }

            db.ToolUseds.Remove(toolUsed);
            db.SaveChanges();

            return Ok(toolUsed);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToolUsedExists(string id)
        {
            return db.ToolUseds.Count(e => e.Id == id) > 0;
        }
    }
}