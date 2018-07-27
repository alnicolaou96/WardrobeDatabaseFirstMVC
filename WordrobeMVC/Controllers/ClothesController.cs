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
    public class ClothesController : Controller
    {
        private WardrobeDBEntities db = new WardrobeDBEntities();

        // GET: Clothes
        public ActionResult Index()
        {
            var clothes = db.Clothes.Include(c => c.Color).Include(c => c.Occassion).Include(c => c.Season).Include(c => c.Type);
            return View(clothes.ToList());
        }

        // GET: Clothes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cloth cloth = db.Clothes.Find(id);
            if (cloth == null)
            {
                return HttpNotFound();
            }
            return View(cloth);
        }

        // GET: Clothes/Create
        public ActionResult Create()
        {
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName");
            ViewBag.OccassionID = new SelectList(db.Occassions, "OcassionID", "OcassionName");
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "SeasonName");
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Category");
            return View();
        }

        // POST: Clothes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClothingID,Name,Photo,TypeID,ColorID,OccassionID,SeasonID")] Cloth cloth)
        {
            if (ModelState.IsValid)
            {
                db.Clothes.Add(cloth);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", cloth.ColorID);
            ViewBag.OccassionID = new SelectList(db.Occassions, "OcassionID", "OcassionName", cloth.OccassionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "SeasonName", cloth.SeasonID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Category", cloth.TypeID);
            return View(cloth);
        }

        // GET: Clothes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cloth cloth = db.Clothes.Find(id);
            if (cloth == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", cloth.ColorID);
            ViewBag.OccassionID = new SelectList(db.Occassions, "OcassionID", "OcassionName", cloth.OccassionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "SeasonName", cloth.SeasonID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Category", cloth.TypeID);
            return View(cloth);
        }

        // POST: Clothes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClothingID,Name,Photo,TypeID,ColorID,OccassionID,SeasonID")] Cloth cloth)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cloth).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorID = new SelectList(db.Colors, "ColorID", "ColorName", cloth.ColorID);
            ViewBag.OccassionID = new SelectList(db.Occassions, "OcassionID", "OcassionName", cloth.OccassionID);
            ViewBag.SeasonID = new SelectList(db.Seasons, "SeasonID", "SeasonName", cloth.SeasonID);
            ViewBag.TypeID = new SelectList(db.Types, "TypeID", "Category", cloth.TypeID);
            return View(cloth);
        }

        // GET: Clothes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cloth cloth = db.Clothes.Find(id);
            if (cloth == null)
            {
                return HttpNotFound();
            }
            return View(cloth);
        }

        // POST: Clothes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cloth cloth = db.Clothes.Find(id);
            db.Clothes.Remove(cloth);
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
