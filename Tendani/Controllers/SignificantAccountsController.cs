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
    public class SignificantAccountsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/SignificantAccounts
        public IQueryable<SignificantAccount> GetSignificantAccounts()
        {
            return db.SignificantAccounts;
        }

        // GET: api/SignificantAccounts/5
        [ResponseType(typeof(SignificantAccount))]
        public IHttpActionResult GetSignificantAccount(string id)
        {
            SignificantAccount significantAccount = db.SignificantAccounts.Find(id);
            if (significantAccount == null)
            {
                return NotFound();
            }

            return Ok(significantAccount);
        }

        // PUT: api/SignificantAccounts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSignificantAccount(string id, SignificantAccount significantAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != significantAccount.Id)
            {
                return BadRequest();
            }

            db.Entry(significantAccount).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignificantAccountExists(id))
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

        // POST: api/SignificantAccounts
        [ResponseType(typeof(SignificantAccount))]
        public IHttpActionResult PostSignificantAccount(SignificantAccount significantAccount)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            significantAccount.Id= Guid.NewGuid().ToString();
            db.SignificantAccounts.Add(significantAccount);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SignificantAccountExists(significantAccount.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = significantAccount.Id }, significantAccount);
        }

        // DELETE: api/SignificantAccounts/5
        [ResponseType(typeof(SignificantAccount))]
        public IHttpActionResult DeleteSignificantAccount(string id)
        {
            SignificantAccount significantAccount = db.SignificantAccounts.Find(id);
            if (significantAccount == null)
            {
                return NotFound();
            }

            db.SignificantAccounts.Remove(significantAccount);
            db.SaveChanges();

            return Ok(significantAccount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SignificantAccountExists(string id)
        {
            return db.SignificantAccounts.Count(e => e.Id == id) > 0;
        }
    }
}