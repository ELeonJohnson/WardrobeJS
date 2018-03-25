using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WardrobeProject.Models;

namespace WardrobeProject.Controllers
{
    public class WomensOutfitsController : Controller
    {
        private WardobeProjectEntities db = new WardobeProjectEntities();

        // GET: WomensOutfits
        public ActionResult Index()
        {
            var womensOutfits = db.WomensOutfits.Include(w => w.WomensAccessory).Include(w => w.WomensBottom).Include(w => w.WomensSho).Include(w => w.WomensTop);
            return View(womensOutfits.ToList());
        }

        // GET: WomensOutfits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensOutfit womensOutfit = db.WomensOutfits.Find(id);
            if (womensOutfit == null)
            {
                return HttpNotFound();
            }
            return View(womensOutfit);
        }

        // GET: WomensOutfits/Create
        public ActionResult Create()
        {
            ViewBag.WomensAccessoriesID = new SelectList(db.WomensAccessories, "WomensAccessoriesID", "Name");
            ViewBag.WomensBottomsID = new SelectList(db.WomensBottoms, "WomensBottomsID", "Name");
            ViewBag.WomensShoesID = new SelectList(db.WomensShoes, "WomensShoesID", "Name");
            ViewBag.WomensTopsID = new SelectList(db.WomensTops, "WomensTopsID", "Name");
            return View();
        }

        // POST: WomensOutfits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WomensOutfitID,WomensBottomsID,WomensAccessoriesID,WomensShoesID,WomensTopsID")] WomensOutfit womensOutfit)
        {
            if (ModelState.IsValid)
            {
                db.WomensOutfits.Add(womensOutfit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WomensAccessoriesID = new SelectList(db.WomensAccessories, "WomensAccessoriesID", "Name", womensOutfit.WomensAccessoriesID);
            ViewBag.WomensBottomsID = new SelectList(db.WomensBottoms, "WomensBottomsID", "Name", womensOutfit.WomensBottomsID);
            ViewBag.WomensShoesID = new SelectList(db.WomensShoes, "WomensShoesID", "Name", womensOutfit.WomensShoesID);
            ViewBag.WomensTopsID = new SelectList(db.WomensTops, "WomensTopsID", "Name", womensOutfit.WomensTopsID);
            return View(womensOutfit);
        }

        // GET: WomensOutfits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensOutfit womensOutfit = db.WomensOutfits.Find(id);
            if (womensOutfit == null)
            {
                return HttpNotFound();
            }
            ViewBag.WomensAccessoriesID = new SelectList(db.WomensAccessories, "WomensAccessoriesID", "Name", womensOutfit.WomensAccessoriesID);
            ViewBag.WomensBottomsID = new SelectList(db.WomensBottoms, "WomensBottomsID", "Name", womensOutfit.WomensBottomsID);
            ViewBag.WomensShoesID = new SelectList(db.WomensShoes, "WomensShoesID", "Name", womensOutfit.WomensShoesID);
            ViewBag.WomensTopsID = new SelectList(db.WomensTops, "WomensTopsID", "Name", womensOutfit.WomensTopsID);
            return View(womensOutfit);
        }

        // POST: WomensOutfits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WomensOutfitID,WomensBottomsID,WomensAccessoriesID,WomensShoesID,WomensTopsID")] WomensOutfit womensOutfit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(womensOutfit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WomensAccessoriesID = new SelectList(db.WomensAccessories, "WomensAccessoriesID", "Name", womensOutfit.WomensAccessoriesID);
            ViewBag.WomensBottomsID = new SelectList(db.WomensBottoms, "WomensBottomsID", "Name", womensOutfit.WomensBottomsID);
            ViewBag.WomensShoesID = new SelectList(db.WomensShoes, "WomensShoesID", "Name", womensOutfit.WomensShoesID);
            ViewBag.WomensTopsID = new SelectList(db.WomensTops, "WomensTopsID", "Name", womensOutfit.WomensTopsID);
            return View(womensOutfit);
        }

        // GET: WomensOutfits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WomensOutfit womensOutfit = db.WomensOutfits.Find(id);
            if (womensOutfit == null)
            {
                return HttpNotFound();
            }
            return View(womensOutfit);
        }

        // POST: WomensOutfits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WomensOutfit womensOutfit = db.WomensOutfits.Find(id);
            db.WomensOutfits.Remove(womensOutfit);
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
