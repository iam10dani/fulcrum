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
    public class ClientToolsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ClientTools
        public IQueryable<ClientTool> GetClientTools()
        {
            return db.ClientTools;
        }

        // GET: api/ClientTools/5
        [ResponseType(typeof(ClientTool))]
        public IHttpActionResult GetClientTool(string id)
        {
            ClientTool clientTool = db.ClientTools.Find(id);
            if (clientTool == null)
            {
                return NotFound();
            }

            return Ok(clientTool);
        }

        // PUT: api/ClientTools/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClientTool(string id, ClientTool clientTool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientTool.Id)
            {
                return BadRequest();
            }

            db.Entry(clientTool).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientToolExists(id))
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

        // POST: api/ClientTools
        [ResponseType(typeof(ClientTool))]
        public IHttpActionResult PostClientTool(ClientTool clientTool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            clientTool.Id = Guid.NewGuid().ToString();

            db.ClientTools.Add(clientTool);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ClientToolExists(clientTool.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = clientTool.Id }, clientTool);
        }

        // DELETE: api/ClientTools/5
        [ResponseType(typeof(ClientTool))]
        public IHttpActionResult DeleteClientTool(string id)
        {
            ClientTool clientTool = db.ClientTools.Find(id);
            if (clientTool == null)
            {
                return NotFound();
            }

            db.ClientTools.Remove(clientTool);
            db.SaveChanges();

            return Ok(clientTool);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientToolExists(string id)
        {
            return db.ClientTools.Count(e => e.Id == id) > 0;
        }
    }
}