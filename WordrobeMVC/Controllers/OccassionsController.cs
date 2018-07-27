using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WordrobeMVC;

namespace WordrobeMVC.Controllers
{
    public class OccassionsController : Controller
    {
        private WardrobeDBEntities db = new WardrobeDBEntities();

        // GET: Occassions
        public ActionResult Index()
        {
            return View(db.Occassions.ToList());
        }

        // GET: Occassions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occassion occassion = db.Occassions.Find(id);
            if (occassion == null)
            {
                return HttpNotFound();
            }
            return View(occassion);
        }

        // GET: Occassions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Occassions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OcassionID,OcassionName")] Occassion occassion)
        {
            if (ModelState.IsValid)
            {
                db.Occassions.Add(occassion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(occassion);
        }

        // GET: Occassions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occassion occassion = db.Occassions.Find(id);
            if (occassion == null)
            {
                return HttpNotFound();
            }
            return View(occassion);
        }

        // POST: Occassions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OcassionID,OcassionName")] Occassion occassion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(occassion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(occassion);
        }

        // GET: Occassions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Occassion occassion = db.Occassions.Find(id);
            if (occassion == null)
            {
                return HttpNotFound();
            }
            return View(occassion);
        }

        // POST: Occassions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Occassion occassion = db.Occassions.Find(id);
            db.Occassions.Remove(occassion);
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
