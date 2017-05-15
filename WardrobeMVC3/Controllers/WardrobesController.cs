using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeMVC3.Models;

namespace WardrobeMVC3.Controllers
{
    public class WardrobesController : Controller
    {
        private Wardrobe3MVCEntities db = new Wardrobe3MVCEntities();

        // GET: Wardrobes
        public ActionResult Index()
        {
            var wardrobes = db.Wardrobes.Include(w => w.Color).Include(w => w.Item).Include(w => w.Occasion).Include(w => w.Season);
            return View(wardrobes.ToList());
        }

        // GET: Wardrobes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wardrobe wardrobe = db.Wardrobes.Find(id);
            if (wardrobe == null)
            {
                return HttpNotFound();
            }
            return View(wardrobe);
        }

        // GET: Wardrobes/Create
        public ActionResult Create()
        {
            ViewBag.ColorsID = new SelectList(db.Colors, "ColorsID", "Color1");
            ViewBag.ItemsID = new SelectList(db.Items, "ItemsID", "Item1");
            ViewBag.OccasionsID = new SelectList(db.Occasions, "OccasionsID", "Occasion1");
            ViewBag.SeasonsID = new SelectList(db.Seasons, "SeasonsID", "Season1");
            return View();
        }

        // POST: Wardrobes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WardrodeID,FirstName,LastName,ColorsID,ItemsID,OccasionsID,SeasonsID,Photos")] Wardrobe wardrobe)
        {
            if (ModelState.IsValid)
            {
                db.Wardrobes.Add(wardrobe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ColorsID = new SelectList(db.Colors, "ColorsID", "Color1", wardrobe.ColorsID);
            ViewBag.ItemsID = new SelectList(db.Items, "ItemsID", "Item1", wardrobe.ItemsID);
            ViewBag.OccasionsID = new SelectList(db.Occasions, "OccasionsID", "Occasion1", wardrobe.OccasionsID);
            ViewBag.SeasonsID = new SelectList(db.Seasons, "SeasonsID", "Season1", wardrobe.SeasonsID);
            return View(wardrobe);
        }

        // GET: Wardrobes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wardrobe wardrobe = db.Wardrobes.Find(id);
            if (wardrobe == null)
            {
                return HttpNotFound();
            }
            ViewBag.ColorsID = new SelectList(db.Colors, "ColorsID", "Color1", wardrobe.ColorsID);
            ViewBag.ItemsID = new SelectList(db.Items, "ItemsID", "Item1", wardrobe.ItemsID);
            ViewBag.OccasionsID = new SelectList(db.Occasions, "OccasionsID", "Occasion1", wardrobe.OccasionsID);
            ViewBag.SeasonsID = new SelectList(db.Seasons, "SeasonsID", "Season1", wardrobe.SeasonsID);
            return View(wardrobe);
        }

        // POST: Wardrobes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WardrodeID,FirstName,LastName,ColorsID,ItemsID,OccasionsID,SeasonsID,Photos")] Wardrobe wardrobe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wardrobe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ColorsID = new SelectList(db.Colors, "ColorsID", "Color1", wardrobe.ColorsID);
            ViewBag.ItemsID = new SelectList(db.Items, "ItemsID", "Item1", wardrobe.ItemsID);
            ViewBag.OccasionsID = new SelectList(db.Occasions, "OccasionsID", "Occasion1", wardrobe.OccasionsID);
            ViewBag.SeasonsID = new SelectList(db.Seasons, "SeasonsID", "Season1", wardrobe.SeasonsID);
            return View(wardrobe);
        }

        // GET: Wardrobes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wardrobe wardrobe = db.Wardrobes.Find(id);
            if (wardrobe == null)
            {
                return HttpNotFound();
            }
            return View(wardrobe);
        }

        // POST: Wardrobes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wardrobe wardrobe = db.Wardrobes.Find(id);
            db.Wardrobes.Remove(wardrobe);
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
