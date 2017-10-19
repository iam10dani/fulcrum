using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tendani.Models;

namespace Tendani.Controllers
{
    public class ProceduresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            return View(db.Procedures.ToList());
        }


        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedure procedure = db.Procedures.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(procedure);
        }
        
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Name,Description,AuditProgram,AuditEvidenceType,DA_Level")] Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                procedure.Id = Guid.NewGuid().ToString();
                db.Procedures.Add(procedure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(procedure);
        }


        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedure procedure = db.Procedures.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(procedure);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Name,Description,AuditProgram,AuditEvidenceType,DA_Level")] Procedure procedure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procedure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(procedure);
        }

        
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procedure procedure = db.Procedures.Find(id);
            if (procedure == null)
            {
                return HttpNotFound();
            }
            return View(procedure);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Procedure procedure = db.Procedures.Find(id);
            if (procedure != null) db.Procedures.Remove(procedure);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}