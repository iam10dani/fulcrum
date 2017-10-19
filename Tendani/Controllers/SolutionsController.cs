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
    public class SolutionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Solutions
        public IQueryable<Solution> GetSolutions()
        {
            return db.Solutions;
        }

        // GET: api/Solutions/5
        [ResponseType(typeof(Solution))]
        public IHttpActionResult GetSolution(string id)
        {
            Solution solution = db.Solutions.Find(id);
            if (solution == null)
            {
                return NotFound();
            }

            return Ok(solution);
        }

        // PUT: api/Solutions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSolution(string id, Solution solution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != solution.Id)
            {
                return BadRequest();
            }

            db.Entry(solution).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SolutionExists(id))
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

        // POST: api/Solutions
        [ResponseType(typeof(Solution))]
        public IHttpActionResult PostSolution(Solution solution)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            solution.Id = Guid.NewGuid().ToString();
            db.Solutions.Add(solution);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SolutionExists(solution.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = solution.Id }, solution);
        }

        // DELETE: api/Solutions/5
        [ResponseType(typeof(Solution))]
        public IHttpActionResult DeleteSolution(string id)
        {
            Solution solution = db.Solutions.Find(id);
            if (solution == null)
            {
                return NotFound();
            }

            db.Solutions.Remove(solution);
            db.SaveChanges();

            return Ok(solution);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SolutionExists(string id)
        {
            return db.Solutions.Count(e => e.Id == id) > 0;
        }
    }
}