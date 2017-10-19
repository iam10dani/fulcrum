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
    public class AssertionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Assertions
        public IQueryable<Assertion> GetAssertions()
        {
            return db.Assertions;
        }

        // GET: api/Assertions/5
        [ResponseType(typeof(Assertion))]
        public IHttpActionResult GetAssertion(string id)
        {
            Assertion assertion = db.Assertions.Find(id);
            if (assertion == null)
            {
                return NotFound();
            }

            return Ok(assertion);
        }

        // PUT: api/Assertions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAssertion(string id, Assertion assertion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != assertion.Id)
            {
                return BadRequest();
            }

            db.Entry(assertion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssertionExists(id))
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

        // POST: api/Assertions
        [ResponseType(typeof(Assertion))]
        public IHttpActionResult PostAssertion(Assertion assertion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            assertion.Id = Guid.NewGuid().ToString();
            db.Assertions.Add(assertion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AssertionExists(assertion.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = assertion.Id }, assertion);
        }

        // DELETE: api/Assertions/5
        [ResponseType(typeof(Assertion))]
        public IHttpActionResult DeleteAssertion(string id)
        {
            Assertion assertion = db.Assertions.Find(id);
            if (assertion == null)
            {
                return NotFound();
            }

            db.Assertions.Remove(assertion);
            db.SaveChanges();

            return Ok(assertion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AssertionExists(string id)
        {
            return db.Assertions.Count(e => e.Id == id) > 0;
        }
    }
}